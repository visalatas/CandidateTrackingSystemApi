using AutoMapper;
using CandidateCore.Dtos;
using CandidateCore.Models;
using CandidateCore.Repository;
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
        public DepartmentController(IRepository<Department, int> departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<List<DepartmentDto>> GetAllAsync()
        {
           var departments = await _departmentRepository.Where().Include(x => x.Positions).ToListAsync();

           return _mapper.Map<List<DepartmentDto>>(departments);
        }
    }
}
