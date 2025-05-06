using Scholar.Core.Dtos;
using Scholar.Core.Entities;
using Scholar.Core.Interfaces;
using Scholar.Database.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholar.Database.Services
{
    public class StudentService : IStudentService
    {
        public readonly IStudentRepo studentRepo;

        public StudentService(IStudentRepo studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsWithGradesAsync()
        {
            var students = await this.studentRepo.GetAllStudentsWithGradesAsync();
            return students.Select(MapToStudentDto);
        }

        public async Task<StudentDto> GetStudentByIdWithGradesAsync(int id)
        {
            var student = await this.studentRepo.GetStudentByIdWithGradesAsync(id);
            if (student == null) return null;
            return MapToStudentDto(student);
        }

        private StudentDto MapToStudentDto(Student student)
        {
            return new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Birthday = student.Birthday,
                Grades = student.Grades?.Select(g => new GradeDto
                {
                    Id = g.Id,
                    Subject = g.Subject,
                    Value = g.Value,
                    DateReceived = g.DateReceived
                }).ToList() ?? new List<GradeDto>()
            };
        }
    }
}
