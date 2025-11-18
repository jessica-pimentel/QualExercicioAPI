using QualExercicioAPI.Models.Entities.Exercises;

namespace QualExercicioAPI.Models.Entities.Student
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
