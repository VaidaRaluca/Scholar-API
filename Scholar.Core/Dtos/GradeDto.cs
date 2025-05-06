using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholar.Core.Dtos
{
    public class GradeDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public double Value { get; set; }
        public DateTime DateReceived { get; set; }
    }
}
