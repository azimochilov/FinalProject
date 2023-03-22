using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RecruitmentPlatform.Data.Contexts;
using RecruitmentPlatform.Data.IRepository;
using RecruitmentPlatform.Domain.Entities;

namespace RecruitmentPlatform.Data.Repository;
public class VacancyApplyRepository : IVacancyApplyRepository
{
    private readonly AppDbContext appDbContext = new AppDbContext();
    public async ValueTask<bool> DeleteAsync(long id)
    {
        VacancyApply entity = await appDbContext.VacancyApplies.FirstOrDefaultAsync(user => user.Id == id);
        if (entity == null)
        {
            return false;
        }
        appDbContext.VacancyApplies.Remove(entity);
        await appDbContext.SaveChangesAsync();
        return true;
    }

    public async ValueTask<VacancyApply> InsertAsync(VacancyApply vacancy)
    {
        EntityEntry<VacancyApply> entityEntry = await appDbContext.VacancyApplies.AddAsync(vacancy);
        appDbContext.SaveChanges();
        return entityEntry.Entity;
    }

    public IQueryable<VacancyApply> SelectAllAsync()
    {
        return appDbContext.VacancyApplies.Where(e => true);
    }

    public async ValueTask<VacancyApply> SelectAsync(long id)
    {
        VacancyApply entity = appDbContext.VacancyApplies.FirstOrDefault(u => u.Id == id);
        if (entity == null)
        {
            return null;
        }
        return entity;
    }

    public async ValueTask<VacancyApply> UpdateAsync(VacancyApply vacancy)
    {
        if (await appDbContext.VacancyApplies.FirstOrDefaultAsync(e => e.Id == vacancy.Id) is not null)
        {
            var updatedEntity = (appDbContext.VacancyApplies.Update(vacancy)).Entity;
            appDbContext.SaveChanges();
            return updatedEntity;
        }

        return null;
    }
}
