using ExcelTechnologies.BAL.NCD;
using ExcelTechnologiesModel.NCD;
using Microsoft.AspNetCore.Mvc;


namespace ExcelTechnologies.WebAPI.Areas.NCD.Controllers
{
    [Route("api/NCD/[controller]")]
    [ApiController]
    public class NCDController : ControllerBase
    {
        private readonly INCDRepository _ncdRepository;

        public NCDController(INCDRepository ncdRepository)
        {
            _ncdRepository = ncdRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NCDModel>>> GetAllNCD()
        {
            var ncdData = await _ncdRepository.GetAllNCD();
            return Ok(ncdData);
        }
    }
}
