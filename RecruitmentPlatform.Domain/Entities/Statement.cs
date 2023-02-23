using RecruitmentPlatform.Domain.Commons;
using RecruitmentPlatform.Domain.Enums;

namespace RecruitmentPlatform.Domain.Entities;
public class Statement : Auditable
{
    public long WorkerId { get; set; }
    public long JobTableId { get; set; }
    public long CvtId { get; set; }
    public CheckProccess Check { get; set; } = CheckProccess.Pending;
}
