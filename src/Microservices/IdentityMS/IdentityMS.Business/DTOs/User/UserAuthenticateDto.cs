using IdentityMS.Business.DTOs.Enums;

namespace IdentityMS.Business.DTOs.User
{
    public class UserAuthenticateDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Roles Role { get; set; }
    }
}
