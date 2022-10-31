using CandidateCore.Models;

namespace CandidateCore.Dtos
{
    public class PositionDto: BaseDto
    {
        public string PositionName { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
