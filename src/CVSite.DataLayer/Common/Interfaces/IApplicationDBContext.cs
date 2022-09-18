using CVSite.Domain.Master;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CVSite.Application.Common.Interfaces
{
    public interface IApplicationDBContext
    {
        DbSet<CurriculumVitae> CVs { get; }
        DbSet<Address> Addresses { get; }
        DbSet<Education> Educations { get; }
        DbSet<Interest> Interests { get; }
        DbSet<Person> Persons { get; }
        DbSet<Profile> Profiles { get; }
        DbSet<WorkingHistory> WorkingHistories { get; }
        Task<int> SaveChangesAsync();
    }
}
