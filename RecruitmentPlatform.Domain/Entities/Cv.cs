using RecruitmentPlatform.Domain.Commons;
using RecruitmentPlatform.Domain.Enums;

namespace RecruitmentPlatform.Domain.Entities;
public class Cv :Auditable
{
    public string CvLink { get; set; }
    public LevelOfWorker Level { get; set; }
    public float Experience { get; set; }
    public string Education { get; set; }
    public long WorkerId { get; set; }

}
