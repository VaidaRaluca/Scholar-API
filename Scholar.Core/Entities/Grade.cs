using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholar.Core.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public double Value { get; set; }
        public DateTime DateReceived { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
