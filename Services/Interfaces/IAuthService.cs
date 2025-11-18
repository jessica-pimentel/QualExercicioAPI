using QualExercicioAPI.Models.Entities.User;

namespace QualExercicioAPI.Services.Interfaces
{
    public interface IAuthService
    {
        User Validate(string email, string password);
    }
}
