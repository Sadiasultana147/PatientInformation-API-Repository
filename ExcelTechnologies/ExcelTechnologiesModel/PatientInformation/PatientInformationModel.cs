using ExcelTechnologiesModel.NCD;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTechnologiesModel.PatientInformation
{
    public class PatientInformationModel
    {
        [Key]
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string NCDID { get; set; }
        public int DiseaseID { get; set; }
        public string AllergiesID { get; set; }
        public string Epilepsy { get; set; }
        
    }


}
