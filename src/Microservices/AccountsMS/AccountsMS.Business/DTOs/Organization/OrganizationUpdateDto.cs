namespace AccountsMS.Business.DTOs.Organization
{
    public class OrganizationUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Hometown { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
