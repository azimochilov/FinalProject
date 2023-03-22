using Newtonsoft.Json;

namespace RecruitmentPlatform.Domain.Entities;
public class OverAll
{
    [JsonProperty("results")]
    public Result Result { get; set; }
}
