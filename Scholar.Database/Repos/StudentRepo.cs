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
    public class StudentRepo : IStudentRepo
    {
        private readonly ScholarDbContext context; // only ctor can set it; it cannot be reassigned

        public StudentRepo(ScholarDbContext context)
        {
            this.context = context;
            
        }
        public async Task<IEnumerable<Student>> GetAllStudentsWithGradesAsync()
        {
            return await this.context.Students // await is for pausing this method, but the rest of the app doesn't freeze
                .Include(s => s.Grades)
                .ToListAsync(); // in order to give me the students w/o freezing the app while waiting for them
        }

        public async Task<Student> GetStudentByIdWithGradesAsync(int id)
        {
            return await this.context.Students
                .Include(s => s.Grades)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
