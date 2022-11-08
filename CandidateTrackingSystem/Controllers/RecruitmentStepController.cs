using AutoMapper;
using CandidateCore.Dtos;
using CandidateCore.Models;
using CandidateCore.Repository;
using CandidateCore.UnitOfWorks;
using CandidateServices.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CandidateTrackingSystem.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpGet]
        public async Task<RecruitmentStepDto> GetAsync(int id)
        {
            var recruitmentStep = await _recruitmentStepRepository.Where(x => x.Id == id).FirstOrDefaultAsync();

            var result = _mapper.Map<RecruitmentStepDto>(recruitmentStep);

            return result;
        }
        [HttpGet]
        public async Task<List<RecruitmentStepDto>> GetAllAsync()
        {
            var recruitmentStep = await _recruitmentStepRepository.Where().Include(x => x.Persons).ToListAsync();
            return _mapper.Map<List<RecruitmentStepDto>>(recruitmentStep);
        }
        [HttpPost]
        public async Task<RecruitmentStepDto> AddAsync(CreateRecruitmentStepDto input)
        {
            var recruitmentStep = _mapper.Map<RecruitmentStep>(input);
            recruitmentStep = await _recruitmentStepRepository.AddAsync(recruitmentStep);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<RecruitmentStepDto>(recruitmentStep);
        }
        [HttpPut]
        public async Task<RecruitmentStepDto> UpdateAsync(UpdateRecruitmentStepDto input)
        {
            var recruitmentStep = await _recruitmentStepRepository.GetByIdAsync((int)input.Id);
            if (recruitmentStep == null) throw new Exception("Hata adım bulunamadı!");
            recruitmentStep.StepQueue = input.StepQueue;
            recruitmentStep.StepName = input.StepName;
            await _recruitmentStepRepository.UpdateAsync(recruitmentStep);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<RecruitmentStepDto>(recruitmentStep);
        }
        [HttpDelete]
        public async Task RemoveAsync(int id)
        {
            var recruitmentStep = await _recruitmentStepRepository.GetByIdAsync(id);
            await _recruitmentStepRepository.RemoveAsync(recruitmentStep);
            await _unitOfWork.CommitAsync();
        }
    }
}
