using CandidateCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateServices.Dtos
{
    public class UpdateStepDto
    {
        public int Id { get; set; }
        public PersonStatus Status { get; set; } 
    }
}
