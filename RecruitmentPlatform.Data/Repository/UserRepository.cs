using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RecruitmentPlatform.Data.Contexts;
using RecruitmentPlatform.Data.IRepository;
using RecruitmentPlatform.Domain.Entities;

namespace RecruitmentPlatform.Data.Repository;
public class UserRepository : IUserRepository
{
    private readonly AppDbContext appDbContext = new AppDbContext();
    public async ValueTask<bool> DeleteAsync(long id)
    {
        User entity = await appDbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        if (entity == null)
        {
            return false;
        }
        appDbContext.Users.Remove(entity);
        await appDbContext.SaveChangesAsync();
        return true;
    }

    public async ValueTask<User> InsertAsync(User user)
    {
        EntityEntry<User> entityEntry = await appDbContext.Users.AddAsync(user);
        appDbContext.SaveChanges();
        return entityEntry.Entity;
    }

    public  IQueryable<User> SelectAllAsync()
    {
        return appDbContext.Users.Where(e => true);
    }

    public async ValueTask<User> SelectAsync(long id)
    {
        User entity = appDbContext.Users.FirstOrDefault(u => u.Id == id);
        if (entity == null)
        {
            return null;
        }
        return entity;
    }

    public async ValueTask<User> UpdateAsync(User user)
    {
        
        if (await appDbContext.Users.FirstOrDefaultAsync(e => e.Id == user.Id) is not null)
        {
            var updatedEntity = (appDbContext.Users.Update(user)).Entity;
            appDbContext.SaveChanges();
            return updatedEntity;
        }
        return null;
        
    }

}
