using RecruitmentPlatform.Domain.Entities;

namespace RecruitmentPlatform.Data.IRepository;
public interface IVacancyRepositroy
{
    public ValueTask<Vacancy> InsertAsync(Vacancy vacany);
    public ValueTask<Vacancy> UpdateAsync(Vacancy vacany);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<Vacancy> SelectAsync(long id);
    public IQueryable<Vacancy> SelectAllAsync();
}
