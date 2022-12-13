﻿using CandidateCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateServices.Dtos
{
    public class GetAllResultDto<T>
    {
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
    }
}
