using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateServices.Dtos
{
    public class PositionListDto
    {
        public int Id { get; set; }
        public string SearchText { get; set; }
        public int DepartmentId { get; set; }


    }
}
