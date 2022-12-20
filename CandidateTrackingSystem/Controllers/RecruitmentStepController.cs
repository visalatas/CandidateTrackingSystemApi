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
        public async Task<List<RecruitmentStepDto>> GetAllAsync([FromQuery]RecruitmentListDto input)
        {
            var recruitmentStep = _recruitmentStepRepository.Where();

            if (!string.IsNullOrEmpty(input.SearchText))
                recruitmentStep = recruitmentStep.Where(x => x.StepName.Contains(input.SearchText) || x.StepQueue.ToString().Contains(input.SearchText));


            //var   = input.SearchText.Deneme();


            //await recruitmentStep.Include(x => x.Persons).ToListAsync();
            return _mapper.Map<List<RecruitmentStepDto>>(recruitmentStep);
        }
        [HttpGet]
        public async Task<List<AllTableDto>> GetAllPersonAsync([FromQuery]GetAllPersonInput input)
        {
            var list =await _recruitmentStepRepository.Where().OrderBy(x=>x.StepQueue) 
                .Include(x => x.Persons
                    .Where(y => y.Status==input.Status && 
                            (string.IsNullOrEmpty(input.SearchText) ? 
                                true : 
                                    (y.Name.Contains(input.SearchText) || y.SurName.Contains(input.SearchText) || y.Mail.Contains(input.SearchText)))
                            && (input.PositionId > 0 ? y.PositionId == input.PositionId : true)))
                .ThenInclude(x => x.Position)
                .ThenInclude(x => x.Department)
                .ToListAsync();
            return _mapper.Map<List<AllTableDto>>(list);
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


    public static class Merhaba
    {
        public static string Deneme(this string deger)
        {
            return "Ms. " + deger;
        }
    }
}
