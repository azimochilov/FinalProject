using RecruitmentPlatform.Domain.Enums;

namespace RecruitmentPlatform.Service.DTOs;
public class CvCreationDto
{
    public long WrokerId { get; set; }
    public string CvLink { get; set; }
    public LevelOfWorker Level { get; set; }
    public float Experience { get; set; }
    public string Education { get; set; }
}
