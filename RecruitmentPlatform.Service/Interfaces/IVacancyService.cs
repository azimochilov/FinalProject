using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.Helpers;

namespace RecruitmentPlatform.Service.Interfaces;
public interface IVacancyService
{
    ValueTask<Response<Vacancy>> AddAsync(Vacancy vacancy);
    ValueTask<Response<Vacancy>> UpdateAsync(long id, Vacancy vacancy);
    ValueTask<Response<bool>> DeleteAsync(long id);
    ValueTask<Response<Vacancy>> GetByIdAsync(long id);
    ValueTask<Response<List<Vacancy>>> GetAllAsync();
}
