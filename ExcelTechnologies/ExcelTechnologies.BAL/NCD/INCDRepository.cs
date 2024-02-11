using ExcelTechnologiesModel.NCD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTechnologies.BAL.NCD
{
    public interface INCDRepository
    {
        Task<IEnumerable<NCDModel>> GetAllNCD();
    }
}
