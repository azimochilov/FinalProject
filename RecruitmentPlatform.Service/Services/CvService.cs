using RecruitmentPlatform.Data.GenericRepository;
using RecruitmentPlatform.Data.IGenericRepository;
using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.DTOs;
using RecruitmentPlatform.Service.Helpers;
using RecruitmentPlatform.Service.Interfaces;

namespace RecruitmentPlatform.Service.Services;
public class CvService : ICv
{
    private readonly IGenericRepository<Cv> genericRepository = new GenericRepository<Cv>();

    public async Task<Response<Cv>> CreatAsync(CvCreationDto cvCreationDto)
    {
        var values = await genericRepository.GetAllAsync();
        var value = values.FirstOrDefault(p => p.CvLink == cvCreationDto.CvLink);
        if (value is not null)
        {
            return new Response<Cv>()
            {
                StatusCode = 404,
                Message = "Already exists !",
                Value = null
            };
        }
         Cv mappedCv = new Cv()
        {
            WorkerId = cvCreationDto.WrokerId,
            CvLink = cvCreationDto.CvLink,
            Education = cvCreationDto.Education,
            Experience= cvCreationDto.Experience,
            Level= cvCreationDto.Level,
            CreatedAt = DateTime.Now
        };
        await genericRepository.CreateAsync(mappedCv);
        return new Response<Cv>()
        {
            StatusCode = 200,
            Message = "Success !",
            Value = mappedCv
        };

    }

    public async Task<Response<bool>> DeleteAsync(string cvLink)
    {
        var values = await genericRepository.GetAllAsync();
        var value = values.FirstOrDefault(p => p.CvLink == cvLink);
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

    public async Task<Response<List<Cv>>> GetAllAsync(CvCreationDto cvCreationDto)
    {
        return new Response<List<Cv>>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = await genericRepository.GetAllAsync()
        };
    }



    public async Task<Response<Cv>> GetByCvLinkAysnc(string cvLink)
    {
        var values = await genericRepository.GetAllAsync();
        var value = values.FirstOrDefault(p => p.CvLink == cvLink);
        if (value is null)
        {
            return new Response<Cv>()
            {
                StatusCode = 404,
                Message = "Already exsists!",
                Value = null
            };
        }
        await genericRepository.GetByIdAsync(value.Id);
        return new Response<Cv>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = value
        };
    }

    public async Task<Response<Cv>> UpdateAsync(string oldCvLink, CvCreationDto cvCreationDto)
    {
        var values = await genericRepository.GetAllAsync();
        var value = values.FirstOrDefault(p => p.CvLink == oldCvLink);

        if (value is null)
        {
            return new Response<Cv>()
            {
                StatusCode = 404,
                Message = "Not Found!",
                Value = null
            };
        }

        value.CvLink = cvCreationDto.CvLink;
        value.Education = cvCreationDto.Education;
        value.Experience = cvCreationDto.Experience;
        value.Level = cvCreationDto.Level;  
        value.UpdatedAt = DateTime.UtcNow;
        await genericRepository.UpdateAsync(value.Id, value);
        return new Response<Cv>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = value
        };
    }
}
