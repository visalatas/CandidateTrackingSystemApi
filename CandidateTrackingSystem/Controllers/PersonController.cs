using AutoMapper;
using CandidateCore.Models;
using CandidateCore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidateTrackingSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IRepository<Person, Int64> _personRepository;
        private readonly IMapper _mapper;
        public PersonController(IRepository<Person, Int64> personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
    }
}
