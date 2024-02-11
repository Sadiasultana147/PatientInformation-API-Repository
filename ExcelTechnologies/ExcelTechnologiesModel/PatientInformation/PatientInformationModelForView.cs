using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTechnologiesModel.PatientInformation
{
    public class PatientInformationModelForView
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string? NCDID { get; set; }
        public int DiseaseID { get; set; }
        public string AllergiesID { get; set; }
        public string Epilepsy { get; set; }
        public string? DiseaseName { get; set; }
        public string? AllergiesName { get; set; }
        public string? NCDName { get; set; }
        
    }
}
