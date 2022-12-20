using CandidateCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateServices.Dtos
{
    public class GetAllPersonInput
    {
        public PersonStatus Status { get; set; }
        public string? SearchText { get; set; }
        public int? PositionId { get; set; }
    }
}
