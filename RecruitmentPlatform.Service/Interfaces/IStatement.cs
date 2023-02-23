using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.DTOs;
using RecruitmentPlatform.Service.Helpers;

namespace RecruitmentPlatform.Service.Interfaces;
public interface IStatement
{
    
    Task<Response<Statement>> CreatAsync(StatementCreationDto statementCreationDto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<Statement>> UpdateAsync(long id, StatementCreationDto statementCreationDto);
    Task<Response<List<Statement>>> GetAllAsync();
}
