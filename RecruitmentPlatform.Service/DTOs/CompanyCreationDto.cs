using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Domain.Enums;

namespace RecruitmentPlatform.Service.DTOs;

public class CompanyCreationDto
{
    public string Name { get; set; }
    public CompanyType Type { get; set; }
    public AdressCreationDto Adres { get; set; }

}
