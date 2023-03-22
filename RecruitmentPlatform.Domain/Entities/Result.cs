using Newtonsoft.Json;
using RecruitmentPlatform.Domain.Commons;

namespace RecruitmentPlatform.Domain.Entities;
public class Result : Auditable
{
    [JsonProperty("vacancies")]
    public List<Wrapper> Wrapper { get; set;}

}
