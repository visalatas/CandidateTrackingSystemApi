using AutoMapper;
using CandidateCore.Dtos;
using CandidateCore.Models;

namespace CandidateCore.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
        CreateMap<Person, PersonDto>().ReverseMap();
        CreateMap<Position, PositionDto>().ReverseMap();
        CreateMap<Department, DepartmentDto>().ReverseMap();
        CreateMap<RecruitmentStep, RecruitmentStepDto>().ReverseMap();
        }
    }
}
