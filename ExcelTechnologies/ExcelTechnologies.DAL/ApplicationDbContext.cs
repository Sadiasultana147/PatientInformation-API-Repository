using ExcelTechnologiesModel.Allergies;
using ExcelTechnologiesModel.Disease;
using ExcelTechnologiesModel.NCD;
using ExcelTechnologiesModel.PatientInformation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTechnologies.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<NCDModel> NCD { get; set; }
        public DbSet<AllergiesModel> Allergies { get; set; }
        public DbSet<DiseaseInformationModel> DiseaseInformation { get; set; }
        public DbSet<PatientInformationModel> PatientsInformation { get; set; }
        public DbSet<NCDDetails> NCD_Details { get; set; }
        public DbSet<AllergiesDetails> Allergies_Details { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
    }
}
