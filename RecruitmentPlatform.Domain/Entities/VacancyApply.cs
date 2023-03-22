using RecruitmentPlatform.Domain.Commons;

namespace RecruitmentPlatform.Domain.Entities;
public class VacancyApply : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long VacancyId { get; set; }
    public Vacancy Vacancy { get; set; }
}
