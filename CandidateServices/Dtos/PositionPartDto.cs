using CandidateCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateServices.Dtos
{
    public class PositionPartDto : BaseDto
    {
        public string PositionName { get; set; }
        public int DepartmentId { get; set; }
    }
}
