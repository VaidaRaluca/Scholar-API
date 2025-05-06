using Microsoft.AspNetCore.Mvc;
using Scholar.Core.Interfaces;
using Scholar.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Scholar.Core.Dtos;
namespace Scholar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScholarController : ControllerBase
    {
        private readonly IStudentService studentService;

        public ScholarController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        // GET
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudentDto>),200)]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAllStudentsWithGrades()
        {
            var students = await this.studentService.GetAllStudentsWithGradesAsync();
            return Ok(students); //http 200
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudentDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<StudentDto>> GetStudentByIdWithGrades(int id)
        {
            var student = await this.studentService.GetStudentByIdWithGradesAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }
    }
}
