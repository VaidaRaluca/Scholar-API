using Microsoft.AspNetCore.Mvc;
using Scholar.Core.Entities;
using Scholar.Core.Interfaces;
using Scholar.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scholar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            var students = await studentService.GetAllStudentsWithGradesAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var student = await studentService.GetStudentByIdWithGradesAsync(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }


    }
}