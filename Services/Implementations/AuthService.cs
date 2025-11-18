using QualExercicioAPI.Models.Entities.User;
using QualExercicioAPI.Models.Enum;
using QualExercicioAPI.Services.Interfaces;

namespace QualExercicioAPI.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private static readonly List<User> FakeUsers = new()
        {
            new User { Id = 1, Email = "admin@teste.com", PasswordHash = "123", Role = RoleEnum.Admin },
            new User { Id = 2, Email = "aluno@teste.com", PasswordHash = "123", Role = RoleEnum.Student }
        };

        public User Validate(string email, string password)
        {
            return FakeUsers.FirstOrDefault(u =>
                u.Email == email && u.PasswordHash == password
            );
        }
    }
}
