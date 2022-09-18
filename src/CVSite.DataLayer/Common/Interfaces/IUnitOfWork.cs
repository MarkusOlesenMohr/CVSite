using CVSite.Domain.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVSite.Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEfRepository<CurriculumVitae> EntityRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
