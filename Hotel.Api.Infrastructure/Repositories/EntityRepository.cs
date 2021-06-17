using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using Hotel.Api.Application.Common.Interfaces;
using Hotel.Api.Domain.Entities;
using Hotel.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;


namespace Hotel.Api.Infrastructure.Repositories
{
    public partial class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fields
        private readonly ApplicationDbContext _databaseContext;
        protected readonly DbSet<TEntity> _table;
        #endregion

        #region Ctor
        public EntityRepository(
            ApplicationDbContext databaseContext)
        {
            _databaseContext = databaseContext;
            _table = _databaseContext.Set<TEntity>();
        }
        #endregion

        #region Methods
        public virtual async Task<TEntity> GetByIdAsync(int? id)
        {
            if (!id.HasValue || id == 0)
                return null;
            return await _table.FirstOrDefaultAsync(x => x.Id == id);
        }
        public virtual async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                await _table.AddAsync(entity);
                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be added: {ex.Message}");
            }
        }
        public virtual async Task InsertAsync(IList<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            await _table.AddRangeAsync(entities);
            await _databaseContext.SaveChangesAsync();
            transaction.Complete();
        }
        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                _table.Update(entity);
                _databaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {e.Message}");
            }
        }
        public virtual void Update(IList<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            if (!entities.Any())
                return;

            foreach (var entity in entities)
                Update(entity);
        }
        public async Task DeleteAsync(TEntity entity)
        {
            _table.Remove(entity);
            await _databaseContext.SaveChangesAsync();
        }
        public virtual async Task<TEntity> GetAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null)
        {
            var query = func != null ? func(_table) : _table;
            return await query.FirstOrDefaultAsync();
        }
        public virtual async Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null)
        {
            var query = func != null ? func(_table) : _table;
            return await query.ToListAsync();

        }
        #endregion
    }
}
