using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.DTOs;
using RecruitmentPlatform.Service.Helpers;

namespace RecruitmentPlatform.Service.Interfaces;

public interface ITargetAudience
{
    Task<Response<TargetAudience>> CreatAsync(TargetAudienceCreationDto targetAudienceCreationDto);
    Task<Response<List<TargetAudience>>> GetAllAsync(TargetAudienceCreationDto targetAudienceCreationDto);
    Task<Response<bool>> DeleteAsync(string name);
    Task<Response<TargetAudience>> UpdateAsync(string oldName,TargetAudienceCreationDto targetAudienceCreationDto);
    Task<Response<TargetAudience>> GetByNameAsync(string name);

}
