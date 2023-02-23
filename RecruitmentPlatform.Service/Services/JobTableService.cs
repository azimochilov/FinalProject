using RecruitmentPlatform.Data.GenericRepository;
using RecruitmentPlatform.Data.IGenericRepository;
using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.DTOs;
using RecruitmentPlatform.Service.Helpers;
using RecruitmentPlatform.Service.Interfaces;

namespace RecruitmentPlatform.Service.Services;

public class JobTableService : IJobTable
{
    private readonly IGenericRepository<JobTable> genericRepository = new GenericRepository<JobTable>();
    private readonly IGenericRepository<Statement> statementRepository = new GenericRepository<Statement>();
    public async Task<Response<JobTable>> CreatAsync(JobTableCreationDto jobTableCreationDto)
    {
        var values = await genericRepository.GetAllAsync();
        var value = values.FirstOrDefault(p => p.CompanyId == jobTableCreationDto.CompanyId);
        if (value is not null)
        {
            return new Response<JobTable>()
            {
                StatusCode = 404,
                Message = "Already exists !",
                Value = null
            };
        }
        JobTable mappedJobTable  = new JobTable()
        {
            Salary= jobTableCreationDto.Salary,
            CreatedAt= DateTime.UtcNow,
            CompanyId= jobTableCreationDto.CompanyId
        };
        await genericRepository.CreateAsync(mappedJobTable);    
        return new Response<JobTable>()
        {
            StatusCode = 404,
            Message = "Already exists !",
            Value = mappedJobTable
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

    public async Task<Response<List<Statement>>> IncomingStatements(long id)
    {        
        var values = await statementRepository.GetAllAsync();
        var result = values.FindAll(r=>r.JobTableId == id);
        return new Response<List<Statement>>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = result
        };
    }

    public async Task<Response<JobTable>> UpdateAsync(long id, JobTableCreationDto jobTableCreationDto)
    {
        var values = await genericRepository.GetAllAsync();
        var value = values.FirstOrDefault(p => p.Id == id);

        if (value is null)
        {
            return new Response<JobTable>()
            {
                StatusCode = 404,
                Message = "Not Found!",
                Value = null
            };
        }

        value.Salary = jobTableCreationDto.Salary;
        value.CompanyId = jobTableCreationDto.CompanyId;
        value.UpdatedAt = DateTime.UtcNow;
        await genericRepository.UpdateAsync(id, value);
        return new Response<JobTable>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = value
        };
    }
}
