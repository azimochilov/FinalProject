using Newtonsoft.Json;
using RecruitmentPlatform.Domain.Entities;
using RecruitmentPlatform.Service.DTOs;
using RecruitmentPlatform.Service.Interfaces;
using RecruitmentPlatform.Service.Services;

//ExternalService ex = new ExternalService();
//var temp = await ex.GetCompanyAsync();
//foreach (var item in temp.Value)
//{
//    Console.WriteLine(item.CompanyCode);
//}
UserService cp = new UserService();
UserDto user = new UserDto();
user.Name = "sdasdsadas";
user.Email = "jaxa";
user.Username = "ronaldo";
var cpm = await cp.GetByIdAsync(1);

Console.WriteLine(cpm.Value.Name);

