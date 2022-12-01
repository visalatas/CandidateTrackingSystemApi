using AutoMapper;
using CandidateCore.Dtos;
using CandidateCore.Models;
using CandidateCore.Repository;
using CandidateCore.UnitOfWorks;
using CandidateRepository.UnitOfWorks;
using CandidateServices.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CandidateTrackingSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepository<Department, int> _departmentRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IRepository<Department, int> departmentRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            var departments = await _departmentRepository.Where().Include(x => x.Positions).ToListAsync();

            return _mapper.Map<List<DepartmentDto>>(departments);
        }
        [HttpGet]
        public async Task<DepartmentDto> GetAsync(int id )
        {
            var department = await _departmentRepository.GetAsync(x => x.Id == id);
            return _mapper.Map<DepartmentDto>(department);
        }

        
        [HttpPost]
        public async Task<DepartmentDto> AddAsync(CreateDepartmentDto input)
        {
            var department = _mapper.Map<Department>(input);
            department = await _departmentRepository.AddAsync(department);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<DepartmentDto>(department);
        }
        [HttpPut]
        public async Task<DepartmentDto?> UpdateAsync(UpdateDepartmentDto input)
        {
            var department = await _departmentRepository.GetByIdAsync(input.Id);
            department.DepartmentName = input.DepartmentName;
            await _departmentRepository.UpdateAsync(department);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<DepartmentDto>(department);

        }
        [HttpDelete]
        public async Task RemoveAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            await _departmentRepository.RemoveAsync(department);
            await _unitOfWork.CommitAsync();
           
        }
    }
}
