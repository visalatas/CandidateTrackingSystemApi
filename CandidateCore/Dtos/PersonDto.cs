﻿using CandidateCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateCore.Dtos
{
    public class PersonDto : BaseDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        public int RecruitmentStepId { get; set; }
        public virtual RecruitmentStep RecruitmentStep { get; set; }
    }
}
