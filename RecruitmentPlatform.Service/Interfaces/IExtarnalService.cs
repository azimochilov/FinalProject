using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.Helpers;

namespace RecruitmentPlatform.Service.Interfaces;
public interface IExtarnalService
{
    ValueTask<Response<List<Company>>> GetCompanyAsync();
    ValueTask<Response<List<Vacancy>>> GetVacancyAsync();

}
