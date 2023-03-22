using Newtonsoft.Json;
using RecruitmentPlatform.Domain.Commons;

namespace RecruitmentPlatform.Domain.Entities;
public class Company : Auditable
{
    [JsonProperty("companycode")]
    public string CompanyCode { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("hr-agency")]
    public bool HrAgency { get; set; }

    [JsonProperty("inn")]
    public string Inn { get; set; }
    
    [JsonProperty("kpp")]
    public string Kpp { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("ogrn")]
    public string Ogrn { get; set; }

    [JsonProperty("phone")]
    public string Phone { get; set; }

    [JsonProperty("site")]
    public string Site { get; set; }


    [JsonProperty("url")]
    public string Url { get; set; }   

}
