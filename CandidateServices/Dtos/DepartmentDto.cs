using CandidateCore.Models;
using CandidateServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateCore.Dtos
{
    public class DepartmentDto : BaseDto
    {
        public string DepartmentName { get; set; }
        public  List<PositionPartDto> Positions { get; set; }
    }
}
