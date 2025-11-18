namespace QualExercicioAPI.Models.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
    }
}
