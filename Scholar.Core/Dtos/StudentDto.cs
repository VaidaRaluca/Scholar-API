using Scholar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholar.Core.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime Birthday { get; set; }
        public int Age => CalculateAge(Birthday);
        public List<GradeDto> Grades { get; set; } = new List<GradeDto>();
        private int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

        public double AverageGrade => CalculateAverageGrade(Grades);

        private double CalculateAverageGrade(List<GradeDto> grades)
        {
            if (grades == null || grades.Count == 0)
                return 0;

            return (double)Math.Round(grades.Average(g => g.Value));
        }

    }
}
