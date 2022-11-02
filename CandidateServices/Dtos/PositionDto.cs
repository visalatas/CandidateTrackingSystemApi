using CandidateCore.Models;
using CandidateServices.Dtos;

namespace CandidateCore.Dtos
{
    public class PositionDto: BaseDto
    {
        public string PositionName { get; set; }
        public int DepartmentId { get; set; }
        public virtual DepartmentPartDto Department { get; set; }
        public virtual List<PersonDto> Persons { get; set; }
    }
}
