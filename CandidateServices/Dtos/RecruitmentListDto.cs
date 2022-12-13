using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateServices.Dtos
{
    public class RecruitmentListDto
    {
        public string? SearchText { get; set; }
        public int page { get; set; }
        public int DataCount { get; set; }
    }
}
