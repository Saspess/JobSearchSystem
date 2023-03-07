﻿namespace AccountsMS.Business.DTOs.Employee
{
    public class EmployeeUpdateDto
    {
        public int Id { get; set; }
        public int? OrganizationId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Hometown { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
