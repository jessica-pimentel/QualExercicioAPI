using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace QualExercicioAPI.Models.Entities.Student
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasMany(s => s.Exercises)
                .WithOne()
                .HasForeignKey(e => e.StudentId);
        }
    }
}
