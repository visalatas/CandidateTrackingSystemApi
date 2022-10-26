using CandidateCore.Models;
using CandidateCore.Repository;
using CandidateCore.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidateTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IRepository<Department, int> _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;



        public TestController(IRepository<Department, int> departmentRepository, IUnitOfWork unitOfWork)
        {
            _departmentRepository= departmentRepository;
            _unitOfWork = unitOfWork;

        }
        
       
         
        [HttpGet]
        public List<Department> Get()
        {
            var result= _departmentRepository.GetAllAsync().Result.ToList();
            return result;
        }
    }
    
}
