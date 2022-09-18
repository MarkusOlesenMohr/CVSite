using CVSite.Application.Common.Interfaces;
using CVSite.Domain.Master;
using System;
using System.Threading.Tasks;

namespace CVSite.Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _dbContext;
        private IEfRepository<CurriculumVitae>? _entityRepository;

        public UnitOfWork(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEfRepository<CurriculumVitae> EntityRepository
        {
            get { return _entityRepository ??= new EfRepository<CurriculumVitae>(_dbContext); }
        }

        public void Commit()
            => _dbContext.SaveChanges();


        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();


        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();

        void IDisposable.Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
