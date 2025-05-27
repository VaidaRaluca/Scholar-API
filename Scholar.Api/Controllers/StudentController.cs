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


        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetById(int id)
        {
            var student = await studentService.GetStudentByIdWithGradesAsync(id);
            if (student == null)
                return NotFound();

            return Ok(student); 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll([FromQuery] StudentFilterDto filter)
        {
            var students = await studentService.GetAllStudentsWithGradesAsync();

            var filtered = students.AsQueryable();


            // filtering
            if (filter.FilterByTopGrades)
                filtered = filtered.Where(s => s.AverageGrade >= 9);

            if (filter.FilterByAdults)
                filtered = filtered.Where(s => s.Age >= 18);

            // sorting
            filtered = filter.SortBy.ToLower() switch
            {
                "age" => filter.SortDescending
                    ? filtered.OrderByDescending(s => s.Age)
                    : filtered.OrderBy(s => s.Age),

                "averagegrade" => filter.SortDescending
                    ? filtered.OrderByDescending(s => s.AverageGrade)
                    : filtered.OrderBy(s => s.AverageGrade),

                _ => filter.SortDescending
                    ? filtered.OrderByDescending(s => s.LastName)
                    : filtered.OrderBy(s => s.LastName)
            };


            // pagination
            int skip = (filter.PageNumber - 1) * filter.PageSize;
            var paged = filtered.Skip(skip).Take(filter.PageSize).ToList();

            return Ok(paged);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StudentDto updatedStudent)
        {
            if (id != updatedStudent.Id)
                return BadRequest("ID in URL does not match ID in body.");

            var existing = await studentService.GetStudentByIdWithGradesAsync(id);
            if (existing == null)
                return NotFound();

            var success = await studentService.UpdateStudentAsync(updatedStudent);
            if (!success)
                return StatusCode(500, "Could not update the student.");

            return NoContent(); 
        }


    }
}