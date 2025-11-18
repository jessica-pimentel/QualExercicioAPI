using Microsoft.AspNetCore.Mvc;
using QualExercicioAPI.Services.Interfaces;

namespace QualExercicioAPI.Controllers.v1.features.Upload
{
    [ApiController]
    [Route("api/v1/upload")]
    public class UploadController : ControllerBase
    {
        private readonly IExcelParser _excelParser;

        public UploadController(IExcelParser excelParser)
        {
            _excelParser = excelParser;
        }

        [HttpPost("excel")]
        public async Task<IActionResult> UploadExcel(IFormFile file, int studentId)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Arquivo inválido");

            var exercises = await _excelParser.Parse(file, studentId);

            return Ok(exercises);
        }
    }
}
