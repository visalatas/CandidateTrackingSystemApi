using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateCore.Models
{
    public class Position : BaseEntity
    {
        public string PositionName { get; set; }
        public int DepartmentId { get; set; }
       
        public  Department Department { get; set; }
        public  ICollection<Person> Persons { get; set; }

    }
}
