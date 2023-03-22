using RecruitmentPlatform.Data.IRepository;
using RecruitmentPlatform.Data.Repository;
using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.Helpers;
using RecruitmentPlatform.Service.Interfaces;

namespace RecruitmentPlatform.Service.Services;
public class VacancyApplyService : IVacancyApplyService
{
    private readonly IVacancyApplyRepository vacancyRepository = new VacancyApplyRepository();
    
    public async ValueTask<Response<VacancyApply>> AddAsync(long userId, long vacancyId)
    {
        var vac = vacancyRepository.SelectAllAsync().Where(v => v.Id == vacancyId)
            .ToList().FirstOrDefault();

        if (vac is null)
            return new Response<VacancyApply>
            {
                Code = 404,
                Message = "Not found"
            };
        VacancyApply vacancyApply = new VacancyApply();
        vacancyApply.CreatedAt = DateTime.Now;
        vacancyApply.UserId = userId;
        vacancyApply.VacancyId = vacancyId;
        
        var addedVacancy = await this.vacancyRepository.InsertAsync(vacancyApply);

        return new Response<VacancyApply>
        {
            Code = 404,
            Message = "Success",
            Value = vacancyApply
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
}
