using Microsoft.EntityFrameworkCore;
using VacanciesMS.Data.Contexts.Contracts;
using VacanciesMS.Data.Entities;
using System.Reflection;

namespace VacanciesMS.Data.Contexts.Implementation
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<VacancyEntity> Vacancies { get; set; }
        public DbSet<RespondEntity> Responds { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
