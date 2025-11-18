using OfficeOpenXml;
using QualExercicioAPI.Models.Entities.Exercises;
using QualExercicioAPI.Services.Interfaces;

namespace QualExercicioAPI.IServices.Services
{
    public class ExcelParser : IExcelParser
    {
        public async Task<List<Exercise>> Parse(IFormFile file, int studentId)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);

            using var package = new ExcelPackage(stream);
            var sheet = package.Workbook.Worksheets[0];

            List<Exercise> exercises = new();

            int row = 2;

            while (!string.IsNullOrEmpty(sheet.Cells[row, 1].Value?.ToString()))
            {
                exercises.Add(new Exercise
                {
                    StudentId = studentId,
                    Name = sheet.Cells[row, 1].Value.ToString(),
                    Repetitions = int.Parse(sheet.Cells[row, 2].Value.ToString()),
                    Sets = int.Parse(sheet.Cells[row, 3].Value.ToString()),
                });

                row++;
            }

            return exercises;
        }
    }
}
