using RecruitmentPlatform.Domain.Entities;

namespace RecruitmentPlatform.Data.IRepository;
public interface IVacancyApplyRepository
{
    public ValueTask<VacancyApply> InsertAsync(VacancyApply vacany);
    public ValueTask<VacancyApply> UpdateAsync(VacancyApply vacany);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<VacancyApply> SelectAsync(long id);
    public IQueryable<VacancyApply> SelectAllAsync();
}
