using CandidateCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateServices.Dtos
{
    public class AllTableDto
    {
        public string StepName { get; set; }
        public int StepQueue { get; set; }
        public List<PersonAllDto> Persons { get; set; }
    }
}
