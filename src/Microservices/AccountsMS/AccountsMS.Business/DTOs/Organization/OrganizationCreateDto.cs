namespace AccountsMS.Business.DTOs.Organization
{
    public class OrganizationCreateDto
    {
        public string Name { get; set; } = null!;
        public string Hometown { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
