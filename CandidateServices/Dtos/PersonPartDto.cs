﻿using CandidateCore.Dtos;
using CandidateCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateServices.Dtos
{
    public class PersonPartDto : BaseDto
    {
        public string DepartmentName { get; set; }
        
    }
}