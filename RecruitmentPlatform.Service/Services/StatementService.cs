using RecruitmentPlatform.Data.GenericRepository;
using RecruitmentPlatform.Data.IGenericRepository;
using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Domain.Enums;
using RecruitmentPlatform.Service.DTOs;
using RecruitmentPlatform.Service.Helpers;
using RecruitmentPlatform.Service.Interfaces;

namespace RecruitmentPlatform.Service.Services;
public class StatementService : IStatement
{
    private readonly IGenericRepository<Statement> genericRepository = new GenericRepository<Statement>();
    public async Task<Response<Statement>> CreatAsync(StatementCreationDto statementCreationDto)
    {
        var values = await genericRepository.GetAllAsync();        
        
        Statement mappedStatement = new Statement()
        {
            CvtId = statementCreationDto.CvtId,
            JobTableId= statementCreationDto.JobTableId,
            Check = CheckProccess.Pending,
            CreatedAt = DateTime.Now
        };
        await genericRepository.CreateAsync(mappedStatement);

        return new Response<Statement>()
        {
            StatusCode = 200,
            Message = "Success !",
            Value = mappedStatement
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var values = await genericRepository.GetAllAsync();
        var value = values.FirstOrDefault(p => p.Id == id);
        if (value is null)
        {
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "Failed !",
                Value = false
            };

        }

        await genericRepository.DeleteAsync(value.Id);
        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = true
        };
    }

    public async Task<Response<List<Statement>>> GetAllAsync()
    {
        return new Response<List<Statement>>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = await genericRepository.GetAllAsync()
        };
    }

    public async Task<Response<Statement>> UpdateAsync(long id, StatementCreationDto statementCreationDto)
    {
        var values = await genericRepository.GetAllAsync();
        var value = values.FirstOrDefault(p => p.Id == id);

        if (value is null)
        {
            return new Response<Statement>()
            {
                StatusCode = 404,
                Message = "Not Found!",
                Value = null
            };
        }
        value.WorkerId = statementCreationDto.WorkerId;
        value.CvtId = statementCreationDto.CvtId;
        value.JobTableId = statementCreationDto.JobTableId;         
        value.UpdatedAt = DateTime.UtcNow;
        return new Response<Statement>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = value
        };
    }
}