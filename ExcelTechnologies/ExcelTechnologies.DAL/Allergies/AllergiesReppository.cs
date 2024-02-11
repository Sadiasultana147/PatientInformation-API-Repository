using ExcelTechnologies.BAL.Allergies;
using ExcelTechnologiesModel.Allergies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTechnologies.DAL.Allergies
{
    public class AllergiesReppository : IAllergiesRepository
    {
        private readonly ApplicationDbContext _context;
        public AllergiesReppository(ApplicationDbContext context)
        {
            _context= context;
        }
        public async Task<IEnumerable<AllergiesModel>> GetAllAllergies()
        {
            return await _context.Allergies.ToListAsync();
        }
    }
}
