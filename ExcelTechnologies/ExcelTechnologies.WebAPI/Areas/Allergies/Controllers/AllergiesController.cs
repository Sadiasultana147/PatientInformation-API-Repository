using ExcelTechnologies.BAL.Allergies;
using ExcelTechnologiesModel.Allergies;
using ExcelTechnologiesModel.NCD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExcelTechnologies.WebAPI.Areas.Allergies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly IAllergiesRepository _allergiesRepository;
        public AllergiesController(IAllergiesRepository allergiesRepository)
        {
            _allergiesRepository = allergiesRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllergiesModel>>> GetAllAlergies()
        {
            var allergies = await _allergiesRepository.GetAllAllergies();
            return Ok(allergies);
        }
    }
}
