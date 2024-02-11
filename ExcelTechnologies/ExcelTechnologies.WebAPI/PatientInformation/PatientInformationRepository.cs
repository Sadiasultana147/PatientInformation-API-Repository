using ExcelTechnologies.BAL.PatientInformation;
using ExcelTechnologies.DAL;
using ExcelTechnologiesModel.Allergies;
using ExcelTechnologiesModel.NCD;
using ExcelTechnologiesModel.PatientInformation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ExcelTechnologies.WebAPI.PatientInformation
{
    public class PatientInformationRepository: IPatientInformationRepository
    {
        private readonly ApplicationDbContext _context;
        public PatientInformationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        //Get All Patient List
        // Get All Patient List
        public async Task<IEnumerable<PatientInformationModelForView>> GetAllPatients()
        {
            var patients = await _context.PatientsInformation
                .Select(p => new
                {
                    Patient = p,
                    NCDID = p.NCDID,
                    AllergiesID = p.AllergiesID,
                    Epilepsy = p.Epilepsy
                })
                .ToListAsync();

            var processedPatients = patients.SelectMany(p => p.NCDID.Split(',').Select(n => new { Patient = p.Patient, NCDID = int.TryParse(n.Trim(), out var parsedNCDID) ? parsedNCDID : (int?)null, p.AllergiesID, p.Epilepsy }))
                .SelectMany(p => p.AllergiesID.Split(',').Select(a => new { p.Patient, p.NCDID, AllergiesID = int.TryParse(a.Trim(), out var parsedAllergiesID) ? parsedAllergiesID : (int?)null, p.Epilepsy }))
                .Select(p => new { p.Patient, p.NCDID, p.AllergiesID, p.Epilepsy })
                .GroupJoin(
                    _context.DiseaseInformation,
                    pd => pd.Patient.DiseaseID,
                    d => d.DiseaseID,
                    (pd, diseases) => new { pd.Patient, pd.NCDID, pd.AllergiesID, pd.Epilepsy, Diseases = diseases }
                )
                .SelectMany(
                    pd => pd.Diseases.DefaultIfEmpty(),
                    (pd, d) => new { pd.Patient, pd.NCDID, pd.AllergiesID, pd.Epilepsy, Disease = d }
                )
                .GroupBy(p => new { p.Patient.PatientID, p.Patient.PatientName, p.Epilepsy })
                .Select(group => new PatientInformationModelForView
                {
                    PatientID = group.Key.PatientID,
                    PatientName = group.Key.PatientName,
                    Epilepsy = group.Key.Epilepsy,
                    NCDID = string.Join(", ", group.Select(g => g.NCDID.HasValue ? g.NCDID.Value.ToString() : "").Distinct()),
                    NCDName = string.Join(", ", _context.NCD.Where(n => group.Select(g => g.NCDID).Contains(n.NCDID)).Select(n => n.NCDName)),
                    DiseaseID = group.Select(g => g.Disease.DiseaseID).FirstOrDefault(),
                    DiseaseName = group.Select(g => g.Disease?.DiseaseName).FirstOrDefault(),
                    AllergiesID = string.Join(", ", group.Select(g => g.AllergiesID.HasValue ? g.AllergiesID.Value.ToString() : "").Distinct()),
                    AllergiesName = string.Join(", ", _context.Allergies.Where(a => group.Select(g => g.AllergiesID).Contains(a.AllergiesID)).Select(a => a.AllergiesName))
                })
                .ToList();

            return processedPatients;
        }


        //Insert New Data
        public async Task InsertPatientData(PatientInformationModel patient)
        {
            try
            {
                _context.PatientsInformation.Add(patient);
                await _context.SaveChangesAsync();

                if (patient.NCDID != null)
                {
                    string ncdIdString = patient.NCDID.ToString();
                    string[] ncdIds = ncdIdString.Split(',');
                    foreach (var ncdId in ncdIds)
                    {
                        int ncdIdValue;
                        if (int.TryParse(ncdId.Trim(), out ncdIdValue))
                        {
                            NCDDetails ncdDetails = new NCDDetails
                            {
                                NCDID = ncdIdValue,
                                PatientID = patient.PatientID
                            };

                            _context.NCD_Details.Add(ncdDetails);
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                if (patient.AllergiesID != null)
                {
                    string allergiesId = patient.AllergiesID.ToString();
                    string[] allergiesIds = allergiesId.Split(',');
                    foreach (var allergie in allergiesIds)
                    {
                        int allergiesIdValue;
                        if (int.TryParse(allergie.Trim(), out allergiesIdValue))
                        {
                            AllergiesDetails allergiesDetails = new AllergiesDetails
                            {
                                AllergiesID = allergiesIdValue,
                                PatientID = patient.PatientID
                            };

                            _context.Allergies_Details.Add(allergiesDetails);
                        }
                    }

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error: {ex.Message}");
                // Throw the exception
                throw ;
            }
        }
        //Get Patient By PatientId
        public async Task<PatientInformationModelForView> GetPatientById(int patientId)
        {           
            var patient = await _context.PatientsInformation.Where(x => x.PatientID == patientId).FirstOrDefaultAsync();            
            if (patient == null)
                Console.WriteLine($"Patient with ID {patientId} not found.");
            var ncdIds = patient.NCDID?.Split(',').Where(id => !string.IsNullOrEmpty(id)).Select(int.Parse).ToList();
            var allergiesIds = patient.AllergiesID?.Split(',').Where(id => !string.IsNullOrEmpty(id)).Select(int.Parse).ToList();
            // Map database fields to the view model properties
            var patientViewModel = new PatientInformationModelForView
            {
                PatientID = patient.PatientID,
                PatientName = patient.PatientName,
                DiseaseID = patient.DiseaseID,
                NCDID = ncdIds != null ? string.Join(",", ncdIds) : null,
                AllergiesID = allergiesIds != null ? string.Join(",", allergiesIds) : null,
                Epilepsy = patient.Epilepsy
            };
            return patientViewModel;
        }
        //Delete Data By PatientId
        public async Task<bool> DeletePatientById(int patientId)
        {
            var patient = await _context.PatientsInformation.FindAsync(patientId);
            if (patient == null)
            {
                return false;
            }
            // Delete related Data from Allergies_Details and NCD_Details tables
            _context.Allergies_Details.RemoveRange(_context.Allergies_Details.Where(a => a.PatientID == patientId));
            _context.NCD_Details.RemoveRange(_context.NCD_Details.Where(n => n.PatientID == patientId));
            // Delete the patient from the PatientsInformation table
            _context.PatientsInformation.Remove(patient);
            // Save changes to the database
            await _context.SaveChangesAsync();
            return true; 
        }
        //Update Data By PatientId
        public async Task<bool> UpdatePatient(PatientInformationModel patient)
        {
            var existingPatient = await _context.PatientsInformation.FindAsync(patient.PatientID);

            if (existingPatient == null)
            {
                return false;
            }
            // Update patient's info
            _context.Entry(existingPatient).CurrentValues.SetValues(patient);
            // Update related data in NCD_Details table
            if (!string.IsNullOrEmpty(patient.NCDID))
            {
                var ncdIds = patient.NCDID.Split(',').Select(int.Parse).ToList();
                _context.NCD_Details.RemoveRange(_context.NCD_Details.Where(nd => nd.PatientID == patient.PatientID));
                foreach (var ncdId in ncdIds)
                {
                    _context.NCD_Details.Add(new NCDDetails { PatientID = patient.PatientID, NCDID = ncdId });
                }
            }

            // Update related data in Allergies_Details table
            if (!string.IsNullOrEmpty(patient.AllergiesID))
            {
                var allergiesIds = patient.AllergiesID.Split(',').Select(int.Parse).ToList();
                _context.Allergies_Details.RemoveRange(_context.Allergies_Details.Where(ad => ad.PatientID == patient.PatientID));
                foreach (var allergiesId in allergiesIds)
                {
                    _context.Allergies_Details.Add(new AllergiesDetails { PatientID = patient.PatientID, AllergiesID = allergiesId });
                }
            }
            await _context.SaveChangesAsync();

            return true; 
        }

    }



}

