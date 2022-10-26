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
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
           await _dbSet.AddAsync(entity);
           return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TPrimaryKey id)
        {
            var result = await _dbSet.FirstOrDefaultAsync();

            return result;
        }

        public async Task RomoveAsync(TEntity entity)
        {
            await Task.Run(() => {
                _dbSet.Remove(entity);
            });
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => {
               _dbSet.Update(entity);
            });
        }
    }
}
