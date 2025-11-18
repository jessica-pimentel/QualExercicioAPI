using QualExercicioAPI.Models.Entities.Exercises;

namespace QualExercicioAPI.Services.Interfaces
{
    public interface IExcelParser
    {
        Task<List<Exercise>> Parse(IFormFile file, int studentId);
    }
}
