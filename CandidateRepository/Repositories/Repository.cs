using CandidateCore.Models;
using CandidateCore.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateRepository.Repositories
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>
    {
        protected readonly CondidateDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(CondidateDbContext context, DbSet<TEntity> dbSet)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>()
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
        }

        public Task<TEntity> GetByIdAsync(TPrimaryKey id)
        {
        }

        public Task RomoveAsync(TEntity entity)
        {
        }

        public Task UpdateAsync(TEntity entity)
        {
        }
    }
}
