using Microsoft.EntityFrameworkCore;
using Scholar.Core.Entities;
using Scholar.Core.Interfaces;
using Scholar.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholar.Database.Repos
{
    public class GradeRepo : IGradeRepo
    {
        private readonly ScholarDbContext context;
        public GradeRepo(ScholarDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Grade>> GetGradesByStudentIdAsync(int studentId)
        {
            return await this.context.Grades
                .Where(g => g.StudentId == studentId)
                .ToListAsync();
        }
    }
}
