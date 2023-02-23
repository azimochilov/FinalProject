using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.DTOs;
using RecruitmentPlatform.Service.Helpers;

namespace RecruitmentPlatform.Service.Interfaces;
public interface ICv
{
    Task<Response<Cv>> CreatAsync(CvCreationDto cvCreationDto);
    Task<Response<List<Cv>>> GetAllAsync(CvCreationDto cvCreationDto);
    Task<Response<bool>> DeleteAsync(string cvLink);
    Task<Response<Cv>> UpdateAsync(string oldCvLink, CvCreationDto cvCreationDto);
    Task<Response<Cv>> GetByCvLinkAysnc(string cvLink);
}
