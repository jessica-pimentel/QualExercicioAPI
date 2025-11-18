using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QualExercicioAPI.Models.Entities.Exercises
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.ToTable("Exercises");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(e => e.Repetitions)
                .HasMaxLength(50);

            builder.Property(e => e.Sets)
                .HasMaxLength(50);

            builder.Property(e => e.ImageBase64)
                .HasMaxLength(300);
        }
    }
}
