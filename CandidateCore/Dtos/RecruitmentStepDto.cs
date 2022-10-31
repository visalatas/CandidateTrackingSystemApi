﻿using CandidateCore.Models;
namespace CandidateCore.Dtos
{
    public class RecruitmentStepDto : BaseDto
    {
        public string StepName { get; set; }
        public int StepQueue { get; set; }
        public virtual ICollection<Person> Persons { get; set; }

    }
}
