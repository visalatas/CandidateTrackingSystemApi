using AutoMapper;
using CandidateCore.Models;
using CandidateCore.Repository;
using CandidateCore.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidateTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentStepController : ControllerBase
    {

        private readonly IRepository<RecruitmentStep, int> _recruitmentStepRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RecruitmentStepController(IRepository<RecruitmentStep, int> recruitmentStepRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _recruitmentStepRepository = recruitmentStepRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }   
}
