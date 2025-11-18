using Microsoft.EntityFrameworkCore;
using QualExercicioAPI.Models.Entities.Exercises;
using QualExercicioAPI.Models.Entities.Student;
using QualExercicioAPI.Models.Entities.User;
using System.Reflection;

namespace QualExercicioAPI.Data
{
    public class QualExercicioDbContext : DbContext
    {
        public QualExercicioDbContext(DbContextOptions<QualExercicioDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Carrega todas as configurations automaticamente
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
