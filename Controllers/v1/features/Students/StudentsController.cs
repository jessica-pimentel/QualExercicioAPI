using Microsoft.AspNetCore.Mvc;
using QualExercicioAPI.Data;
using QualExercicioAPI.Models.Entities.Student;

namespace QualExercicioAPI.Controllers.v1.features.Students
{
    [ApiController]
    [Route("api/v1/students")]
    public class StudentsController : ControllerBase
    {
        private readonly QualExercicioDbContext _db;

        public StudentsController(QualExercicioDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
            return Ok(student);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_db.Students.ToList());
        }
    }
}
