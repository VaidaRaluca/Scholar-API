using Scholar.Core.Dtos;
using Scholar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholar.Core.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsWithGradesAsync();
        Task<StudentDto> GetStudentByIdWithGradesAsync(int id);
    }
}
