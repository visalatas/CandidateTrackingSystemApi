using CandidateCore.Enums;
using CandidateCore.Models;
using CandidateServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateCore.Dtos
{
    public class PersonDto : BaseDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public PersonStatus Status { get; set; } 
        public int PositionId { get; set; }
        public PositionPartDto Position { get; set; }
        public int RecruitmentStepId { get; set; }
        public RecruitmentPartDto RecruitmentStep { get; set; }
       
    }

    // PersonDto => Bağlı olduğu nesneler olur (Yani PartDto'lar)
//     PersonPartDto => Bağlı bir nesne olmaz (Yani dto olmaz)
}
