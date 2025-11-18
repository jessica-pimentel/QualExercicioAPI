using QualExercicioAPI.Models.Enum;

namespace QualExercicioAPI.Models.Entities.User
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public RoleEnum Role { get; set; }
    }
}
