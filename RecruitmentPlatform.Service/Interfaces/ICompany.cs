using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.DTOs;
using RecruitmentPlatform.Service.Helpers;

namespace RecruitmentPlatform.Service.Interfaces;
public interface ICompany
{
    Task<Response<Company>> CreatAsync(CompanyCreationDto companyCreationDto);
    Task<Response<List<Company>>> GetAllAsync(CompanyCreationDto companyCreationDto);
    Task<Response<bool>> DeleteAsync(string name);
    Task<Response<Company>> UpdateAsync(string oldName, CompanyCreationDto companyCreationDto);
    Task<Response<Company>> GetByNameAysnc(string name);
}
