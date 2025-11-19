using QualExercicioAPI.Data;
using QualExercicioAPI.Models.Entities.User;
using QualExercicioAPI.Models.Enum;
using QualExercicioAPI.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace QualExercicioAPI.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly QualExercicioDbContext _db;

        public AuthService(QualExercicioDbContext db)
        {
            _db = db;
        }

        public User ValidateCreate(string name, string email, string password, string confirmPassword)
        {
            if (_db.Users.Any(u => u.Email == email))
                throw new ArgumentException("Este e-mail já está cadastrado.");

            if (password != confirmPassword)
                throw new ArgumentException("As senhas não coincidem.");


            var user = new User
            {
                Name = name,
                Email = email,
                PasswordHash = HashPassword(password),
                Role = Enum.Parse<RoleEnum>(RoleEnum.Student.ToString(), true)
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            return user;
        }

        public User Validate(string email, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
                throw new ArgumentException("Usuário não encontrado.");

            if (!VerifyPassword(password, user.PasswordHash))
                throw new ArgumentException("Senha incorreta.");

            return user;
        }

        public (bool Success, string Message) UpdatePassword(int userId, string oldPassword, string newPassword, string confirmPassword)
        {
            var user = _db.Users.Find(userId);

            if (user == null)
                throw new ArgumentException("Usuário não encontrado.");

            if (!VerifyPassword(oldPassword, user.PasswordHash))
                throw new ArgumentException("Senha incorreta.");

            if (newPassword != confirmPassword)
                throw new ArgumentException("A nova senha e a confirmação não coincidem.");

            user.PasswordHash = HashPassword(newPassword);
            _db.SaveChanges();

            return (true, "Senha atualizada com sucesso.");
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}
