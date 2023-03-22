using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RecruitmentPlatform.Data.Contexts;
using RecruitmentPlatform.Data.IRepository;
using RecruitmentPlatform.Domain.Entities;

namespace RecruitmentPlatform.Data.Repository;
public class CompanyRepository : ICompanyRepository
{
    private readonly AppDbContext appDbContext = new AppDbContext();
    public async ValueTask<bool> DeleteAsync(long id)
    {
        Company entity = await appDbContext.Companies.FirstOrDefaultAsync(user => user.Id == id);
        if (entity == null)
        {
            return false;
        }
        appDbContext.Companies.Remove(entity);
        await appDbContext.SaveChangesAsync();
        return true;
    }

    public async ValueTask<Company> InsertAsync(Company company)
    {
        //company.UpdatedAt= DateTime.Now;
        EntityEntry<Company> entityEntry = await appDbContext.Companies.AddAsync(company);
        appDbContext.SaveChanges();
        return entityEntry.Entity;
    }

    public IQueryable<Company>  SelectAllAsync()
    {
        return appDbContext.Companies.Where(e => true);
    }

    public async ValueTask<Company> SelectAsync(long id)
    {
        Company entity = appDbContext.Companies.FirstOrDefault(u => u.Id == id);
        if (entity == null)
        {
            return null;
        }
        return entity;
    }

    public async ValueTask<Company> UpdateAsync(Company entity)
    {
        if (await appDbContext.Companies.FirstOrDefaultAsync(e => e.Id == entity.Id) is not null)
        {
            var updatedEntity = (appDbContext.Companies.Update(entity)).Entity;
            appDbContext.SaveChanges();
            return updatedEntity;
        }

        return null;
    }

}
