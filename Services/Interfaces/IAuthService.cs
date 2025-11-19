using QualExercicioAPI.Models.Entities.User;

namespace QualExercicioAPI.Services.Interfaces
{
    public interface IAuthService
    {
        User ValidateCreate(string name, string email, string password, string confirmPassword);
        User Validate(string email, string password);
        (bool Success, string Message) UpdatePassword(int userId, string oldPassword, string newPassword, string confirmPassword);
    }
}
