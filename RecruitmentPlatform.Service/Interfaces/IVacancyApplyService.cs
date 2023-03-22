using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.Helpers;

namespace RecruitmentPlatform.Service.Interfaces;
public interface IVacancyApplyService
{
    ValueTask<Response<VacancyApply>> AddAsync(long userId, long vacancyId);
    ValueTask<Response<bool>> DeleteAsync(long id);
}
