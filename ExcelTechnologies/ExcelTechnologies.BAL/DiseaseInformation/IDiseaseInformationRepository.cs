
using ExcelTechnologiesModel.Disease;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTechnologies.BAL.DiseaseInformation
{
    public interface IDiseaseInformationRepository
    {
        Task <IEnumerable<DiseaseInformationModel>> GetAllDisease();
        
    }
}
