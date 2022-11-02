﻿using AutoMapper;
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
        public async Task<List<PositionDto>> GetAllAsync()
        {
            var position = await _positionRepository.Where().Include(x => x.Department).ToListAsync();
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
    }
}