using CandidateCore.Models;

namespace CandidateCore.Dtos
{
    public class PositionDto: BaseDto
    {
        public string PositionName { get; set; }
        public int DepartmentId { get; set; }
        public virtual DepartmentDto Department { get; set; }
        public virtual List<PersonDto> Persons { get; set; }
    }
}
