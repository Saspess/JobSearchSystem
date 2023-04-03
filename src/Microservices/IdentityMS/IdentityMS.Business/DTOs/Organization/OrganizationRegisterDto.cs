using IdentityMS.Business.DTOs.Enums;

namespace IdentityMS.Business.DTOs.Organization
{
    public class OrganizationRegisterDto
    {
        public string Name { get; set; } = null!;
        public string Hometown { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Roles Role { get; set; }
    }
}
