using RecruitmentPlatform.Data.IRepository;
using RecruitmentPlatform.Data.Repository;
using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.Helpers;
using RecruitmentPlatform.Service.Interfaces;

namespace RecruitmentPlatform.Service.Services;
public class VacancyService : IVacancyService
{
    private readonly IVacancyRepositroy vacancyRepository = new VacancyRepository();

    public async ValueTask<Response<Vacancy>> AddAsync(Vacancy vacancy)
    {
        vacancy.CreatedAt = DateTime.Now;
        var addedVacancy = await this.vacancyRepository.InsertAsync(vacancy);
        return new Response<Vacancy>
        {
            Code = 200,
            Message = "Success",
            Value = addedVacancy
        };
    }

    public async ValueTask<Response<bool>> DeleteAsync(long id)
    {
        var vacancy = await this.vacancyRepository.DeleteAsync(id);
        if (vacancy == false)
            return new Response<bool>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = false
            };

        await this.vacancyRepository.DeleteAsync(id);
        return new Response<bool>
        {
            Code = 200,
            Message = "Success",
            Value = true
        };
    }

    public async ValueTask<Response<List<Vacancy>>> GetAllAsync()
    {
        var vacansies = this.vacancyRepository.SelectAllAsync();
        return new Response<List<Vacancy>>
        {
            Code = 200,
            Message = "Success",
            Value = vacansies.ToList()
        };
    }

    public async ValueTask<Response<Vacancy>> GetByIdAsync(long id)
    {
        Vacancy vacancy = await this.vacancyRepository.SelectAsync(id);
        if (vacancy is null)
            return new Response<Vacancy>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = null
            };
        return new Response<Vacancy>
        {
            Code = 200,
            Message = "Success",
            Value = vacancy
        };
    }

    public async ValueTask<Response<Vacancy>> UpdateAsync(long id, Vacancy vacancy)
    {
        Vacancy updatedVac = await this.vacancyRepository.SelectAsync(id);
        if (updatedVac is null)
            return new Response<Vacancy>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = null
            };
        updatedVac.Schedule = vacancy.Schedule;
        updatedVac.Source = vacancy.Source;
        updatedVac.Salary = vacancy.Salary;
        updatedVac.CompanyId = vacancy.CompanyId;
        updatedVac.JobName = vacancy.JobName;   
        updatedVac.CreationDate = vacancy.CreationDate;
        updatedVac.IdStr = vacancy.IdStr;
        updatedVac.UserId = vacancy.UserId;        
        updatedVac.UpdatedAt = DateTime.Now;
        var updated = await this.vacancyRepository.UpdateAsync(updatedVac);
        return new Response<Vacancy>
        {
            Code = 200,
            Message = "Success",
            Value = updated
        };
    }

}
