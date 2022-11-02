using AutoMapper;
using CandidateCore.Dtos;
using CandidateCore.Models;
using CandidateServices.Dtos;

namespace CandidateCore.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
        CreateMap<Person, PersonDto>().ReverseMap();
        CreateMap<Position, PositionDto>().ReverseMap();
        CreateMap<Position, PositionPartDto>().ReverseMap();
        CreateMap<Department, DepartmentDto>().ReverseMap();
        CreateMap<Department, DepartmentPartDto>().ReverseMap();
        CreateMap<RecruitmentStep, RecruitmentStepDto>().ReverseMap();
        CreateMap<CreatePersonDto, Person>();
        CreateMap<CreateDepartmentDto, Department>();
        CreateMap<UpdateDepartmentDto, Department>();
        CreateMap<CreatePositionDto, Position>();
        }
    }
}
