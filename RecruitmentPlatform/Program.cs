using RecruitmentPlatform.Domain.Enums;
using RecruitmentPlatform.Service.DTOs;
using RecruitmentPlatform.Service.Services;
namespace Program; 
public class Program
{
    public async static Task Main()
    {
        //var rep = new TargetAudianceService();
        Console.WriteLine("-----------------------------------");
        Console.WriteLine(File.Exists("..\\..\\..\\..\\RecruimentPlatform.Data\\Databases\\Cv.json"));        
        Console.WriteLine("-----------------------------------");
       

    }
}
