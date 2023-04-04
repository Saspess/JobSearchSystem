using IdentityMS.Business.DTOs.Enums;

namespace IdentityMS.Business.DTOs.Employee
{
    public class EmployeeRegisterDto
    {
        public int? OrganizationId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Hometown { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
