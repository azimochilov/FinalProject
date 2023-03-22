using Newtonsoft.Json;
using RecruitmentPlatform.Domain.Commons;

namespace RecruitmentPlatform.Domain.Entities;
public class Vacancy : Auditable
{
    
    
    [JsonProperty("id")]
    public string IdStr { get; set; }
    [JsonProperty("source")]
    public string Source { get; set; }
    
    public long ? CompanyId { get; set; }    

    [JsonProperty("company")]
    public Company Company { get; set; }

    [JsonProperty("creation-date")]
    public string CreationDate { get; set; }

    [JsonProperty("salary")]
    public string Salary { get; set; }

    [JsonProperty("job-name")]
    public string JobName { get; set; }

    [JsonProperty("schedule")]
    public string Schedule { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}
