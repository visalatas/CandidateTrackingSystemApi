using CandidateCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateServices.Dtos
{
    public class PersonAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public PersonStatus Status { get; set; }
        public int PositionId { get; set; }
        public PositionAllDto Position { get; set; }
    }
}
