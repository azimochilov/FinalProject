using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.DTOs;
using RecruitmentPlatform.Service.Helpers;

namespace RecruitmentPlatform.Service.Interfaces;
public interface IUserService
{
    ValueTask<Response<UserDto>> AddAsync(UserDto user);
    ValueTask<Response<UserDto>> UpdateAsync(long id, UserDto user);
    ValueTask<Response<bool>> DeleteAsync(long id);
    ValueTask<Response<UserDto>> GetByIdAsync(long id);
    ValueTask<Response<List<UserDto>>> GetAllAsync();    
}
