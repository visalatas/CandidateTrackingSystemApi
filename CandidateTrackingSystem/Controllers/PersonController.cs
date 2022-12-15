using AutoMapper;
using CandidateCore.Dtos;
using CandidateCore.Enums;
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
    public class PersonController : ControllerBase
    {
        private readonly IRepository<Person, Int64> _personRepository;
        private readonly IRepository<Position, int> _positionRepository;
        private readonly IRepository<RecruitmentStep, int> _recruitmentStepRepository;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PersonController(IRepository<Person, Int64> personRepository, IMapper mapper, IUnitOfWork unitOfWork, IRepository<Position, int> positionRepository, IRepository<RecruitmentStep, int> recruitmentStepRepository)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _positionRepository = positionRepository;
            _recruitmentStepRepository = recruitmentStepRepository;
        }

        [HttpGet]
        public async Task<List<PersonDto>> GetAllAsync(PersonStatus status)
        {
            var persons = await _personRepository.Where(x => x.Status == status)
                .Include(x => x.Position)
                .ThenInclude(x => x.Department)
                .ToListAsync();

            return _mapper.Map<List<PersonDto>>(persons);
        }

        

        [HttpGet]
        public async Task<PersonDto> GetAsync(int id)
        {
            var person = await _personRepository.Where()
                .Include(x => x.Position)
                .Include(x => x.Position.Department)
                .FirstOrDefaultAsync();
            return _mapper.Map<PersonDto>(person);
        }
        
        [HttpPost]
        public async Task<PersonDto> AddAsync(CreatePersonDto input)
        {
            var recruitmentStep = await _recruitmentStepRepository.Where(x => x.StepQueue==1).FirstOrDefaultAsync();
            if (recruitmentStep == null) throw new Exception("Böyle bir adım bulunamadı");

            var person = _mapper.Map<Person>(input);
            //person.Name = input.Name;
            //person.SurName = input.SurName;
            //person.PhoneNumber = input.PhoneNumber;
            //person.Mail = input.Mail;
            person.RecruitmentStepId = recruitmentStep.Id;
            //person.PositionId = input.PositionId;


            var position = await _positionRepository.Where(x => x.Id == input.PositionId).FirstOrDefaultAsync();
            if (position == null) throw new Exception("Böyle bir pozisyon bulunamadı");

            await _personRepository.AddAsync(person);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<PersonDto>(person);
        }
        [HttpPut]
        public async Task<PersonDto> UpdateAsnyc(UpdatePersonDto input)
        {
            var person = await _personRepository.GetByIdAsync(input.Id);
            person.Name = input.Name;
            person.SurName = input.SurName;
            person.PhoneNumber = input.PhoneNumber;
            person.Mail = input.Mail;
            person.PositionId = input.PositionId;
            await _personRepository.UpdateAsync(person);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<PersonDto>(person);
            
        }
        [HttpPut]
        public async Task<PersonDto> UpdateStepAsnyc(UpdateStepDto input)
        {
            var person = await _personRepository.GetByIdAsync(input.Id);
            
            if (input.Status == PersonStatus.Success)
            {
                 var oldStep = await _recruitmentStepRepository.Where(x => x.Id == person.RecruitmentStepId).FirstOrDefaultAsync();

                var newStep = await _recruitmentStepRepository.Where(x => x.StepQueue == oldStep.StepQueue + 1).FirstOrDefaultAsync();
                if (newStep == null)
                {
                    person.Status = PersonStatus.Success;
                }
                else
                {
                    person.RecruitmentStepId = newStep.Id;
                }
            }
            else if(input.Status == PersonStatus.UnSuccess)
            {
                person.Status = PersonStatus.UnSuccess;
            }

            
            await _personRepository.UpdateAsync(person);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<PersonDto>(person);

        }
        [HttpDelete]
        public async Task RemoveAsnyc(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            await _personRepository.RemoveAsync(person);
            await _unitOfWork.CommitAsync();
        }
    }
}
