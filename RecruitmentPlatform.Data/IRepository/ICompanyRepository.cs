using RecruitmentPlatform.Domain.Entities;

namespace RecruitmentPlatform.Data.IRepository;
public interface ICompanyRepository
{
    public ValueTask<Company> InsertAsync(Company company);
    public ValueTask<Company> UpdateAsync(Company company);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<Company> SelectAsync(long id);
    public IQueryable<Company> SelectAllAsync();
}
