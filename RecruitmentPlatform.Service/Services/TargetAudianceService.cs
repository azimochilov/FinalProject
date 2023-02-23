using RecruitmentPlatform.Data.GenericRepository;
using RecruitmentPlatform.Data.IGenericRepository;
using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.DTOs;
using RecruitmentPlatform.Service.Helpers;
using RecruitmentPlatform.Service.Interfaces;

namespace RecruitmentPlatform.Service.Services;

public class TargetAudianceService : ITargetAudience
{
    private readonly IGenericRepository<TargetAudience> genericRepository = new GenericRepository<TargetAudience>();
    private readonly IGenericRepository<Cv> cvRepository = new GenericRepository<Cv>();
    private readonly IGenericRepository<Adress> adressRepository = new GenericRepository<Adress>();
    public async Task<Response<TargetAudience>> CreatAsync(TargetAudienceCreationDto targetAudienceCreationDto)
    {
        var values = await genericRepository.GetAllAsync();
        var value = values.FirstOrDefault(p => p.FirstName == targetAudienceCreationDto.FirstName);
        if (value is not null)
        {
            return new Response<TargetAudience>()
            {
                StatusCode = 404,
                Message = "Already exists !",
                Value = null
            };
        }
        Adress Location = new Adress()
        {
            AdressName = targetAudienceCreationDto.AdressDto.AdressName,
            Country = targetAudienceCreationDto.AdressDto.Country,
            ZipCode = targetAudienceCreationDto.AdressDto.ZipCode,
            Region = targetAudienceCreationDto.AdressDto.Region,
            City = targetAudienceCreationDto.AdressDto.City,
            CreatedAt = DateTime.Now
        };
        var resultLocation = await adressRepository.CreateAsync(Location);

        Cv Res = new Cv()
        {
            CvLink = targetAudienceCreationDto.CvDto.CvLink,
            Level =  targetAudienceCreationDto.CvDto.Level,
            Education = targetAudienceCreationDto.CvDto.Education,
            Experience = targetAudienceCreationDto.CvDto.Experience,
            CreatedAt= DateTime.Now,
        };
        var resultCV = await cvRepository.CreateAsync(Res);

        TargetAudience mappedTargetAudience = new TargetAudience()
        {            
            FirstName= targetAudienceCreationDto.FirstName,
            LastName= targetAudienceCreationDto.LastName,
            Email = targetAudienceCreationDto.Email,
            Password= targetAudienceCreationDto.Password,
            Phone = targetAudienceCreationDto.Phone,
            DateOfBirth= targetAudienceCreationDto.DateOfBirth,
            Role = targetAudienceCreationDto.Role,
            AdressId = resultLocation.Id,
            CvId = resultCV.Id,
            CreatedAt = DateTime.Now
        };
        await genericRepository.CreateAsync(mappedTargetAudience);
        return new Response<TargetAudience>()
        {
            StatusCode = 200,
            Message = "Success !",
            Value = mappedTargetAudience
        };

    }

    public async Task<Response<bool>> DeleteAsync(string name)
    {
        var values = await genericRepository.GetAllAsync();
        var value = values.FirstOrDefault(p => p.FirstName == name);
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

    public async Task<Response<List<TargetAudience>>> GetAllAsync(TargetAudienceCreationDto targetAudienceCreationDto)
    {
        return new Response<List<TargetAudience>>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = await genericRepository.GetAllAsync()
        };
    }

    public async Task<Response<TargetAudience>> GetByNameAsync(string name)
    {
        var values = await genericRepository.GetAllAsync();
        var value = values.FirstOrDefault(p => p.FirstName == name);
        if (value is null)
        {
            return new Response<TargetAudience>()
            {
                StatusCode = 404,
                Message = "Already exsists!",
                Value = null
            };
        }
        await genericRepository.GetByIdAsync(value.Id);
        return new Response<TargetAudience>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = value
        };
    }

    public async Task<Response<TargetAudience>> UpdateAsync(string oldName,TargetAudienceCreationDto targetAudienceCreationDto)
    {
        var values = await genericRepository.GetAllAsync();
        var value = values.FirstOrDefault(p => p.FirstName == oldName);

        if (value is null)
        {
            return new Response<TargetAudience>()
            {
                StatusCode = 404,
                Message = "Not Found!",
                Value = null
            };
        }
        Adress Location = new Adress()
        {
            AdressName = targetAudienceCreationDto.AdressDto.AdressName,
            Country = targetAudienceCreationDto.AdressDto.Country,
            ZipCode = targetAudienceCreationDto.AdressDto.ZipCode,
            Region = targetAudienceCreationDto.AdressDto.Region,
            City = targetAudienceCreationDto.AdressDto.City,
            CreatedAt = DateTime.Now
        };
        var resultLocation = await adressRepository.UpdateAsync(value.Id,Location);
        Cv Res = new Cv()
        {
            CvLink = targetAudienceCreationDto.CvDto.CvLink,
            Level = targetAudienceCreationDto.CvDto.Level,
            Education = targetAudienceCreationDto.CvDto.Education,
            Experience = targetAudienceCreationDto.CvDto.Experience,
            CreatedAt = DateTime.Now,
        };
        var resultCV = await cvRepository.UpdateAsync(value.Id, Res);

        value.AdressId = resultLocation.Id;
        value.CvId = resultCV.Id;
        value.FirstName = targetAudienceCreationDto.FirstName;
        value.LastName = targetAudienceCreationDto.LastName;
        value.Email = targetAudienceCreationDto.Email;
        value.Phone = targetAudienceCreationDto.Phone;
        value.DateOfBirth = targetAudienceCreationDto.DateOfBirth;
        value.UpdatedAt = DateTime.UtcNow;
        value.Role= targetAudienceCreationDto.Role;
        await genericRepository.UpdateAsync(value.Id, value);
        return new Response<TargetAudience>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = value
        };
    }
}
