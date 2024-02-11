
using ExcelTechnologiesModel.Allergies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTechnologies.BAL.Allergies
{
    public interface IAllergiesRepository
    {
        Task<IEnumerable<AllergiesModel>> GetAllAllergies();
    }
}
