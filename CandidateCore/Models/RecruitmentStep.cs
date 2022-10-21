using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateCore.Models
{
    public class RecruitmentStep : BaseEntity<int>
    {
        public string StepName { get; set; }
        public int StepQueue { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
