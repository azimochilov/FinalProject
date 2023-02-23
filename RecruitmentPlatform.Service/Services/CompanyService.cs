using RecruitmentPlatform.Data.GenericRepository;
using RecruitmentPlatform.Data.IGenericRepository;
using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.DTOs;
using RecruitmentPlatform.Service.Helpers;
using RecruitmentPlatform.Service.Interfaces;

namespace RecruitmentPlatform.Service.Services;
public class CompanyService : ICompany
{
    private readonly IGenericRepository<Company> genericRepository = new GenericRepository<Company>();
    private readonly IGenericRepository<Adress> AdressRepository = new GenericRepository<Adress>();
    public async Task<Response<Company>> CreatAsync(CompanyCreationDto companyCreationDto)
    {
        var values = await genericRepository.GetAllAsync();
        var value = values.FirstOrDefault(p =>p.Name== companyCreationDto.Name);
        if (value is not null)
        {
            return new Response<Company>()
            {
                StatusCode = 404,
                Message = "Already exists !",
                Value = null
            };
        }
        Adress Location = new Adress()
        {
            AdressName= companyCreationDto.Adres.AdressName,
            Country = companyCreationDto.Adres.Country,
            ZipCode = companyCreationDto.Adres.ZipCode,
            Region= companyCreationDto.Adres.Region,
            City= companyCreationDto.Adres.City,
            CreatedAt = DateTime.Now
        };
        await AdressRepository.CreateAsync(Location);
        Company mappedCompany = new Company()
        {
            Name = companyCreationDto.Name,
            Type = companyCreationDto.Type,                                 
            AdresId = Location.Id,
            CreatedAt = DateTime.Now
        };
        await genericRepository.CreateAsync(mappedCompany);
        return new Response<Company>()
        {
            StatusCode = 200,
            Message = "Success !",
            Value = mappedCompany
        };
    }

    public async Task<Response<bool>> DeleteAsync(string name)
    {
        var values = await genericRepository.GetAllAsync();
        var value = values.FirstOrDefault(p => p.Name == name);
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

    public async Task<Response<List<Company>>> GetAllAsync(CompanyCreationDto companyCreationDto)
    {
        return new Response<List<Company>>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = await genericRepository.GetAllAsync()
        };
    }

    public async Task<Response<Company>> GetByNameAysnc(string name)
    {
        var values = await genericRepository.GetAllAsync();
        var value = values.FirstOrDefault(p => p.Name == name);
        if (value is null)
        {
            return new Response<Company>()
            {
                StatusCode = 404,
                Message = "Already exsists!",
                Value = null
            };
        }
        await genericRepository.GetByIdAsync(value.Id);
        return new Response<Company>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = value
        };
    }

    public async Task<Response<Company>> UpdateAsync(string oldName, CompanyCreationDto companyCreationDto)
    {
        var values = await genericRepository.GetAllAsync();
        var value = values.FirstOrDefault(p => p.Name == oldName);

        if (value is null)
        {
            return new Response<Company>()
            {
                StatusCode = 404,
                Message = "Not Found!",
                Value = null
            };
        }
        Adress Location = new Adress() 
        {
            UpdatedAt= DateTime.Now,
            ZipCode = companyCreationDto.Adres.ZipCode,
            Country = companyCreationDto.Adres.Country, 
            City = companyCreationDto.Adres.City,
            Region= companyCreationDto.Adres.Region,
            AdressName = companyCreationDto.Adres.AdressName
        };
        await AdressRepository.UpdateAsync(value.AdresId,Location);
        value.Name = companyCreationDto.Name;
        value.Type = companyCreationDto.Type;
        value.AdresId = Location.Id;
        value.UpdatedAt = DateTime.Now;        
        await genericRepository.UpdateAsync(value.Id,value);
        return new Response<Company>()
        {
            StatusCode = 200,
            Message = "Success",
            Value = value
        };
    }
}
