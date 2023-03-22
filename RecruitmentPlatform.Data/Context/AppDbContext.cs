using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RecruitmentPlatform.Domain.Entities;
namespace RecruitmentPlatform.Data.Contexts;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = "Server = (localdb)\\MSSQLLocalDB;" +
            "Database = CVdb;" +
            "Trusted_Connection = True";
        optionsBuilder.UseSqlServer(path);
    }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Vacancy> Vacancies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<VacancyApply> VacancyApplies { get; set; }
}