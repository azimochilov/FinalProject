using RecruitmentPlatform.Domain.Commons;
using RecruitmentPlatform.Domain.Enums;

namespace RecruitmentPlatform.Domain.Entities
{
    public class TargetAudience : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }   
        public string Password { get; set; }
        public string DateOfBirth { get; set; }        
        public long AdressId { get; set; }          
        public long CvId { get; set; }
        public UserRole Role { get; set; }  
    }
}
