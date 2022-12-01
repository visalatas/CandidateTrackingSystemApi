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
    public class PositionController : ControllerBase
    {
        private readonly IRepository<Position, int> _positionRepository;
        private readonly IRepository<Department, int> _departmentRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PositionController(IRepository<Position, int> positionRepository, IRepository<Department, int> departmentRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _departmentRepository = departmentRepository;
        }
        [HttpGet]
        public async Task<PositionDto> GetAsync(int id)
        {
            var position = await _positionRepository.Where().Include(x => x.Department).FirstOrDefaultAsync();
            return _mapper.Map<PositionDto>(position);

        }

        [HttpPost]
        public async Task<List<PositionDto>> GetAllAsync(PositionListDto input)
        {
            var query = _positionRepository.Where();
            
            
            if (input.DepartmentId > 0)
            {
                query = query.Where(x => x.DepartmentId == input.DepartmentId);
            }

            if (!string.IsNullOrEmpty(input.SearchText)) 
                query = query.Where(x => x.PositionName.Contains(input.SearchText) || x.Department.DepartmentName.Contains(input.SearchText));
           

            var position = await query.Include(x => x.Department).ToListAsync();
            return _mapper.Map<List<PositionDto>>(position);
        }

        [HttpPost]
        public async Task<PositionDto> AddAsync(CreatePositionDto input)
        {
            var position = _mapper.Map<Position>(input);
            
            var department = await _departmentRepository.Where(x=>x.Id== input.DepartmentId).FirstOrDefaultAsync();
            if (department==null) throw new Exception("Hata Departman bulunamadı!");
            

            position = await _positionRepository.AddAsync(position);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<PositionDto>(position);
        }
        [HttpPut]
        public async Task<PositionDto?> UpdateAsync(UpdatePositionDto input)
        {
            try
            {
                var position = await _positionRepository.GetByIdAsync(input.Id);
                position.PositionName = input.PositionName;
                position.DepartmentId = input.DepartmentId;
                var department = await _departmentRepository.Where(x => x.Id == input.DepartmentId).FirstOrDefaultAsync();
                if (department == null) throw new Exception("Hata Departman bulunamadı!");
                await _positionRepository.UpdateAsync(position);
                await _unitOfWork.CommitAsync();
                return _mapper.Map<PositionDto>(position);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex.InnerException);
            }

        }
        [HttpDelete]
        public async Task RemoveAsync(int id)
        {
            var position = await _positionRepository.GetByIdAsync(id);
            await _positionRepository.RemoveAsync(position);
            await _unitOfWork.CommitAsync();

        }
    }
}
