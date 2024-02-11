using ExcelTechnologies.BAL.NCD;
using ExcelTechnologiesModel.NCD;
using Microsoft.EntityFrameworkCore;


namespace ExcelTechnologies.DAL.NCD
{
    public class NCDRepository : INCDRepository
    {
        private readonly ApplicationDbContext _context;
        public NCDRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<NCDModel>> GetAllNCD()
        {
            return await _context.NCD.ToListAsync();
        }
    }
}
