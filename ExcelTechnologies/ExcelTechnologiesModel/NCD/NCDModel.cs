using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTechnologiesModel.NCD
{
    public class NCDModel
    {
        [Key]
        public int NCDID { get; set; }
        public string NCDName { get; set; }
    }
    public class NCDDetails
    {
        [Key]
        public int ID { get; set; }
        public int PatientID { get; set; }
        public int NCDID { get; set; }
    }
}
