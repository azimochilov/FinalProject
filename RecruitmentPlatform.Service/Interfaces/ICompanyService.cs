using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.Helpers;

namespace RecruitmentPlatform.Service.Interfaces;
public interface ICompanyService
{
    ValueTask<Response<Company>> AddAsync(Company company);
    ValueTask<Response<Company>> UpdateAsync(long id, Company company);
    ValueTask<Response<bool>> DeleteAsync(long id);
    ValueTask<Response<Company>> GetByIdAsync(long id);
    ValueTask<Response<List<Company>>> GetAllAsync();
}
