namespace QualExercicioAPI.Models.Entities.Exercises
{
    public class Exercise
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Repetitions { get; set; }
        public int Sets { get; set; }
        public string ImageBase64 { get; set; }
    }
}
