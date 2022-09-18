using CVSite.Application.Common.Interfaces;
using CVSite.Domain.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVSite.Infrastructure.Database;

public class ApplicationDBContext : DbContext, IApplicationDBContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
     : base(options)
    {
    }
    public DbSet<CurriculumVitae> CVs => Set<CurriculumVitae>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Education> Educations => Set<Education>();
    public DbSet<Interest> Interests => Set<Interest>();
    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<WorkingHistory> WorkingHistories => Set<WorkingHistory>();


    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}
