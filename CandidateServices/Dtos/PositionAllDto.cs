using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateServices.Dtos
{
    public class PositionAllDto
    {
        public string PositionName { get; set; }
        public int DepartmentId { get; set; }
        public virtual DepartmentPartDto Department { get; set; }

    }
}
