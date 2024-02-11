using ExcelTechnologies.BAL.DiseaseInformation;
using ExcelTechnologiesModel.Disease;
using Microsoft.EntityFrameworkCore;

namespace ExcelTechnologies.DAL.DiseaseInformation
{
    public class DiseaseInformationRepository : IDiseaseInformationRepository
    {
        private readonly ApplicationDbContext _context;
        public DiseaseInformationRepository(ApplicationDbContext context)
        {
            _context= context;
        }
        public async Task<IEnumerable<DiseaseInformationModel>> GetAllDisease()
        {
            return await _context.DiseaseInformation.ToListAsync();
        }
    }
}
