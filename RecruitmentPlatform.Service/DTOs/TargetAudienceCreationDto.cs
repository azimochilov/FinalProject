using RecruitmentPlatform.Domain.Enums;

namespace RecruitmentPlatform.Service.DTOs;

public class TargetAudienceCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public string DateOfBirth { get; set; }
    public UserRole Role { get; set; }
    public CvCreationDto CvDto { get; set; }
    public AdressCreationDto AdressDto { get; set; }
    
}
