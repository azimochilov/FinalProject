using RecruitmentPlatform.Domain.Entities;

namespace RecruitmentPlatform.Data.IRepository;
public interface IUserRepository
{
    public ValueTask<User> InsertAsync(User user);
    public ValueTask<User> UpdateAsync(User user);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<User> SelectAsync(long id);
    public IQueryable<User> SelectAllAsync();
}
