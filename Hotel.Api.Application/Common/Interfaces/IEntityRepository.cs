using Hotel.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Api.Application.Common.Interfaces
{
    public partial interface IEntityRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(int? id);
        Task InsertAsync(TEntity entity);
        Task InsertAsync(IList<TEntity> entities);
        void Update(TEntity entity);
        void Update(IList<TEntity> entities);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> GetAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null);
        Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null);
    }
}
