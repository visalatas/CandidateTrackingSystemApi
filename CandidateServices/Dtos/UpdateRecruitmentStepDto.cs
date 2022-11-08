using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateServices.Dtos
{
    public class UpdateRecruitmentStepDto
    {
        public int Id { get; set; }
        public string StepName { get; set; }
        public int StepQueue { get; set; }
    }
}
