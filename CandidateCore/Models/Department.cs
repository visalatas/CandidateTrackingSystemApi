using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateCore.Models
{
    public class Department : BaseEntity
    {
        public string DepartmentName { get; set; }
        public virtual ICollection<Position> Positions { get; set; }

    }
}
