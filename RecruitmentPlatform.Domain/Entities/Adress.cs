using RecruitmentPlatform.Domain.Commons;

namespace RecruitmentPlatform.Domain.Entities;

public class Adress : Auditable
{
    public long WorkerId { get; set; }
    public long ZipCode { get; set; }
    public string Country { get; set; }
    public string Region { get; set; }
    public string City { get; set; }
    public string AdressName { get; set; }
}
