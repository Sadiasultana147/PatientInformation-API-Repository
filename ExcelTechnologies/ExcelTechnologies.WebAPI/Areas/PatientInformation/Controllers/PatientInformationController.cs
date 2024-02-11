using ExcelTechnologies.BAL.PatientInformation;
using ExcelTechnologies.WebAPI.Areas.PatientInformation.Model;
using ExcelTechnologiesModel.NCD;
using ExcelTechnologiesModel.PatientInformation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExcelTechnologies.WebAPI.Areas.PatientInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientInformationController : ControllerBase
    {
        private readonly IPatientInformationRepository _patientInformationRepository;

        public PatientInformationController(IPatientInformationRepository patientInformationRepository)
        {
            _patientInformationRepository = patientInformationRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<bool>>> InsertPatientData(PatientInformationModel patients)
        {
            try
            {
                await _patientInformationRepository.InsertPatientData(patients);
                return new ApiResponse<bool> { Success = true, Data = true };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool> { Success = false, ErrorMessage = ex.Message };
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientInformationModelForView>>> GetAllPatients()
        {
            var patientData = await _patientInformationRepository.GetAllPatients();
            return Ok(patientData);
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetPatientById(int patientId)
        {
            try
            {
                var patient = await _patientInformationRepository.GetPatientById(patientId);
                if (patient == null)
                    return NotFound($"Patient with ID {patientId} not found");

                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeletePatient(int id)
        {
            try
            {
                var result = await _patientInformationRepository.DeletePatientById(id);

                if (!result)
                    return new ApiResponse<bool> { Success = false, ErrorMessage = "Patient not found" };

                return new ApiResponse<bool> { Success = true, Data = true };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool> { Success = false, ErrorMessage = ex.Message };
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> UpdatePatient(int id, PatientInformationModel patientModel)
        {
            try
            {
                if (id != patientModel.PatientID)
                    return new ApiResponse<bool> { Success = false, ErrorMessage = "IDs do not match" };

                var result = await _patientInformationRepository.UpdatePatient(patientModel);

                if (!result)
                    return new ApiResponse<bool> { Success = false, ErrorMessage = "Patient not found" };

                return new ApiResponse<bool> { Success = true, Data = true };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool> { Success = false, ErrorMessage = ex.Message };
            }
        }


    }
}
