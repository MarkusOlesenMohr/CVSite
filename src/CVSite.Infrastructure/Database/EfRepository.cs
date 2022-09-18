using CVSite.Application.Common.Interfaces;
using CVSite.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CVSite.Infrastructure.Database
{
    public class EfRepository<TEntity> : IEfRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        private bool disposedValue;

        public EfRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
            => _dbContext.Add(entity);


        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
            => await _dbContext.AddAsync(entity, cancellationToken);


        public void AddRange(IEnumerable<TEntity> entities)
            => _dbContext.AddRange(entities);


        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
            => await _dbContext.AddRangeAsync(entities, cancellationToken);


        public TEntity? Get(Expression<Func<TEntity, bool>> expression)
            => _dbSet.FirstOrDefault(expression);


        public IEnumerable<TEntity> GetAll()
            => _dbSet.AsEnumerable();


        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
            => _dbSet.Where(expression).AsEnumerable();


        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _dbSet.ToListAsync(cancellationToken);


        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
            => await _dbSet.Where(expression).ToListAsync(cancellationToken);


        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
            => await _dbSet.FirstOrDefaultAsync(expression, cancellationToken: cancellationToken);

        public async Task<TEntity?> GetAsync(int id, CancellationToken cancellationToken = default)
            => await _dbSet.FirstOrDefaultAsync(s => s.Id == id, cancellationToken: cancellationToken);


        public void Remove(TEntity entity)
            => _dbContext.Remove(entity);


        public void RemoveRange(IEnumerable<TEntity> entities)
            => _dbContext.RemoveRange(entities);


        public void Update(TEntity entity)
            => _dbContext.Update(entity);


        public void UpdateRange(IEnumerable<TEntity> entities)
            => _dbContext.UpdateRange(entities);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
