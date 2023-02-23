using RecruitmentPlatform.Domain.Commons;

namespace RecruitmentPlatform.Domain.Entities;
public class JobTable : Auditable
{
    public decimal Salary { get; set; }
    public long CompanyId { get; set; }
    public List<long> StatementIds { get; set; }
}
