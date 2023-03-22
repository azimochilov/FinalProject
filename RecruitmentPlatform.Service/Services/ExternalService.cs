using Newtonsoft.Json;
using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.DTOs;
using RecruitmentPlatform.Service.Helpers;
using RecruitmentPlatform.Service.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RecruitmentPlatform.Service.Services;
public class ExternalService : IExtarnalService
{
    public async ValueTask<Response<List<Company>>> GetCompanyAsync()
    {        
        using var client = new HttpClient();
        var response = await client.GetAsync("http://opendata.trudvsem.ru/api/v1/vacancies");

        var json = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var value = JsonConvert.DeserializeObject<OverAll>(json);
            var vaks = value.Result.Wrapper;
            
            //Console.WriteLine(vak.Vacancy.Id);
            //Console.WriteLine(vak.Vacancy.Source);
            //Console.WriteLine(vak.Vacancy.Company.Kpp);
            List<Company> company = new List<Company>();
            foreach(var vak in vaks)
            {
                company.Add(vak.Vacancy.Company);
            }
            return new Response<List<Company>>
            {
                Code = 200,
                Message = "Success",
                Value= company
            };
        }
        return new Response<List<Company>>
        {
            Code = 200,
            Message = "Success",
            Value = null
        };
    }

    public async ValueTask<Response<List<Vacancy>>> GetVacancyAsync()
    {
        using var client = new HttpClient();
        var response = await client.GetAsync("http://opendata.trudvsem.ru/api/v1/vacancies");

        var json = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var value = JsonConvert.DeserializeObject<OverAll>(json);
            var vaks = value.Result.Wrapper;            
            List<Vacancy> vacancy = new List<Vacancy>();
            foreach (var vak in vaks)
            {                
                vacancy.Add(vak.Vacancy);
            }
            return new Response<List<Vacancy>>
            {
                Code = 200,
                Message = "Success",
                Value = vacancy
            };
        }
        return new Response<List<Vacancy>>
        {
            Code = 404 ,
            Message = "Not found",
            Value = null
        };
    }
}
