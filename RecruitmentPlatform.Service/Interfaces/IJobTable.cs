using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.DTOs;
using RecruitmentPlatform.Service.Helpers;

namespace RecruitmentPlatform.Service.Interfaces;

public interface IJobTable
{
    Task<Response<JobTable>> CreatAsync(JobTableCreationDto jobTableCreationDto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<JobTable>> UpdateAsync(long id, JobTableCreationDto jobTableCreationDto);
    Task<Response<List<Statement>>> IncomingStatements(long id);
}
