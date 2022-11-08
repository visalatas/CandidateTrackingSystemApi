using CandidateCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateServices.Dtos
{
    public class RecruitmentPartDto : BaseDto
    {
        public string StepName { get; set; }
        public int StepQueue { get; set; }
    }
}
