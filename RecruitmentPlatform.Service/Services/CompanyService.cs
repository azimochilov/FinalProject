using RecruitmentPlatform.Data.IRepository;
using RecruitmentPlatform.Data.Repository;
using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.Helpers;
using RecruitmentPlatform.Service.Interfaces;

namespace RecruitmentPlatform.Service.Services;
public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository companyRepository = new CompanyRepository();
    private readonly IExtarnalService extarnal = new ExternalService();

    public async ValueTask<Response<Company>> AddAsync(Company company)
    {                  
        company.CreatedAt = DateTime.Now;
        var addedCompany = await this.companyRepository.InsertAsync(company);         
        return new Response<Company>
        {
            Code = 200,
            Message = "Success",
            Value = addedCompany
        };
    }    
    public async ValueTask<Response<bool>> DeleteAsync(long id)
    {
        var company = await this.companyRepository.DeleteAsync(id);
        if (company == false)
            return new Response<bool>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = false
            };

        await this.companyRepository.DeleteAsync(id);
        return new Response<bool>
        {
            Code = 200,
            Message = "Success",
            Value = true
        };
    }

    public async ValueTask<Response<List<Company>>> GetAllAsync()
    {
        var companies = this.companyRepository.SelectAllAsync();        
        return new Response<List<Company>>
        {
            Code = 200,
            Message = "Success",
            Value = companies.ToList()
        };
    }

    public async ValueTask<Response<Company>> GetByIdAsync(long id)
    {
        Company company = await this.companyRepository.SelectAsync(id);
        if (company is null)
            return new Response<Company>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = null
            };        
        return new Response<Company>
        {
            Code = 200,
            Message = "Success",
            Value = company
        };
    }

    public async ValueTask<Response<Company>> UpdateAsync(long id, Company company)
    {
        Company updatedComp = await this.companyRepository.SelectAsync(id);
        if (updatedComp is null)
            return new Response<Company>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = null
            };
        updatedComp.UpdatedAt = DateTime.Now;
        updatedComp.Kpp = company.Kpp;
        updatedComp.Name = company.Name;
        updatedComp.Phone = company.Phone;
        updatedComp.Email= company.Email;
        updatedComp.Site = company.Site;
        updatedComp.CompanyCode = company.CompanyCode;
        updatedComp.Inn = company.Inn;
        updatedComp.Ogrn = company.Ogrn;
        updatedComp.Url = company.Url;
        var updated = await this.companyRepository.UpdateAsync(updatedComp);        
        return new Response<Company>
        {
            Code = 200,
            Message = "Success",
            Value = updated
        };
    }
}
