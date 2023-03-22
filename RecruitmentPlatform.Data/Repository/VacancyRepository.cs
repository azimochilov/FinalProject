using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RecruitmentPlatform.Data.Contexts;
using RecruitmentPlatform.Data.IRepository;
using RecruitmentPlatform.Domain.Entities;

namespace RecruitmentPlatform.Data.Repository;

public class VacancyRepository : IVacancyRepositroy
{
    private readonly AppDbContext appDbContext = new AppDbContext();
    public async ValueTask<bool> DeleteAsync(long id)
    {
        Vacancy entity = await appDbContext.Vacancies.FirstOrDefaultAsync(user => user.Id == id);
        if (entity == null)
        {
            return false;
        }
        appDbContext.Vacancies.Remove(entity);
        await appDbContext.SaveChangesAsync();
        return true;
    }

    public async ValueTask<Vacancy> InsertAsync(Vacancy vacancy)
    {
        EntityEntry<Vacancy> entityEntry = await appDbContext.Vacancies.AddAsync(vacancy);
        appDbContext.SaveChanges();
        return entityEntry.Entity;
    }

    public IQueryable<Vacancy> SelectAllAsync()
    {
        return appDbContext.Vacancies.Where(e => true);
    }

    public async ValueTask<Vacancy> SelectAsync(long id)
    {
        Vacancy entity = appDbContext.Vacancies.FirstOrDefault(u => u.Id == id);
        if (entity == null)
        {
            return null;
        }
        return entity;
    }

    public async ValueTask<Vacancy> UpdateAsync(Vacancy vacancy)
    {
        if (await appDbContext.Vacancies.FirstOrDefaultAsync(e => e.Id == vacancy.Id) is not null)
        {
            var updatedEntity = (appDbContext.Vacancies.Update(vacancy)).Entity;
            appDbContext.SaveChanges();
            return updatedEntity;
        }

        return null;
    }
}
