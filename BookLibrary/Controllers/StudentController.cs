using Books.Models.Student;
using Books.Services.StudentService;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudentsAsync()
        {
            return await _studentService.GetAllStudentsAsync();
        }

        [HttpGet("{uid}")]
        public async Task<ActionResult<Student>> GetStudentAsync(Guid uid)
        {
            var result = await _studentService.GetStudentAsync(uid);

            if (result is null)
                return NotFound("Student not found!");

            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<List<Student>>> AddStudent([FromBody] Student student)
        {
            var result = await _studentService.AddStudent(student);
            return Ok(result);
        }

        [HttpPut("{uid}")]
        public async Task<ActionResult<List<Student>>> UpdateStudentAsync(Guid uid, Student request)
        {
            var result = await _studentService.UpdateStudentAsync(uid, request);

            if (result is null)
                return NotFound("Student not found!");

            return Ok(result);
        }

        [HttpDelete("{uid}")]
        public async Task<ActionResult<List<Student>>> DeleteStudentAsync(Guid uid)
        {
            var result = await _studentService.DeleteStudentAsync(uid);

            if (result is null)
                return NotFound("Student not found!");

            return Ok(result);
        }
    }
}