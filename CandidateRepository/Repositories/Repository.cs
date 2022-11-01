using CandidateCore.Models;
using CandidateCore.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CandidateRepository.Repositories
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>
    {
        protected readonly CondidateDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(CondidateDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
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

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
           return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await _dbSet.Where(predicate).FirstOrDefaultAsync();
            return result;
        }

        public async Task<TEntity> GetByIdAsync(TPrimaryKey id)
        {
            var result = await _dbSet.FindAsync(id);
            if (result == null) throw new Exception("Lütfen geçerli bir id giriniz!");

            return result;
        }

        public async Task RemoveAsync(TEntity entity)
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

        public IQueryable<TEntity> Where()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}
