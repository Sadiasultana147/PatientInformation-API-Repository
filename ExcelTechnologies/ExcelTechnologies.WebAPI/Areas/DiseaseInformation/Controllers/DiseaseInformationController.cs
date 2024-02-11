using ExcelTechnologies.BAL.DiseaseInformation;
using ExcelTechnologiesModel.Allergies;
using ExcelTechnologiesModel.Disease;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExcelTechnologies.WebAPI.Areas.DiseaseInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseInformationController : ControllerBase
    {
        private readonly IDiseaseInformationRepository _repository;
        public DiseaseInformationController(IDiseaseInformationRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiseaseInformationModel>>> GetAllDisease()
        {
            var diseases = await _repository.GetAllDisease();
            return Ok(diseases);
        }
    }
}
