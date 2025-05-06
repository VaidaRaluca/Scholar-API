using Scholar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholar.Core.Interfaces
{
    public interface IStudentRepo
    {
        Task<IEnumerable<Student>> GetAllStudentsWithGradesAsync();
        Task<Student> GetStudentByIdWithGradesAsync(int id);
    }
}
