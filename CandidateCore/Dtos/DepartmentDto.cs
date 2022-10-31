using CandidateCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateCore.Dtos
{
    public class DepartmentDto : BaseDto
    {
        public string DepartmentName { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
    }
}
