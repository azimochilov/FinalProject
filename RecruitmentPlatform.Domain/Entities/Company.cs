using RecruitmentPlatform.Domain.Commons;
using RecruitmentPlatform.Domain.Enums;

namespace RecruitmentPlatform.Domain.Entities;

public class Company : Auditable
{
    public string Name { get; set; }
    public CompanyType Type { get; set; }
    public long AdresId { get; set; }
    public long AdminId { get; set; }

}
