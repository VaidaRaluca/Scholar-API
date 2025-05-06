using Scholar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholar.Core.Interfaces
{
    public interface IGradeRepo
    {
        Task<IEnumerable<Grade>> GetGradesByStudentIdAsync(int studentId);
    }
}
