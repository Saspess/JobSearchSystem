namespace AccountsMS.Data.Models.Employee
{
    public class EmployeeCreateModel
    {
        public int? OrganizationId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Hometown { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
