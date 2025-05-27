using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholar.Core.Dtos
{
    public class StudentFilterDto
    {
        public bool FilterByTopGrades { get; set; }
        public bool FilterByAdults { get; set; }


        public int PageNumber { get; set; } = 1;  // Default to first page
        public int PageSize { get; set; } = 10;

        public string SortBy { get; set; } = "LastName"; // Default sort
        public bool SortDescending { get; set; } = false;
    }

}
