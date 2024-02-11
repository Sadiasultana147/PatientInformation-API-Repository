using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTechnologiesModel.Allergies
{
    public class AllergiesModel
    {
        [Key]
        public int AllergiesID { get; set; }
        public string AllergiesName { get; set; }
    }
    public class AllergiesDetails
    {
        [Key]
        public int ID { get; set; }
        public int PatientID { get; set; }
        public int AllergiesID { get; set; }
    }
    
}
