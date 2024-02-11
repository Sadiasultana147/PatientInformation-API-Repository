using ExcelTechnologiesModel.PatientInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTechnologies.BAL.PatientInformation
{
    public interface IPatientInformationRepository
    {
        Task InsertPatientData(PatientInformationModel patient);
        Task <IEnumerable<PatientInformationModelForView>> GetAllPatients();
        Task<PatientInformationModelForView> GetPatientById(int patientId);
        Task<bool> DeletePatientById(int patientId);
        Task<bool> UpdatePatient(PatientInformationModel patient);

    }
}
