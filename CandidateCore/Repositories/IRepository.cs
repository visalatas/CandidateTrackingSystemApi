using CandidateCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateCore.Repository
{
    //TEntity tipi BaseEntity veya baseentity den türemiş sınıflar
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>
    {
        //Temel veri tabanı işlemlerini içeren temel depo

        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(TPrimaryKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity entity);
        Task RomoveAsync(TEntity entity);
    }
}
