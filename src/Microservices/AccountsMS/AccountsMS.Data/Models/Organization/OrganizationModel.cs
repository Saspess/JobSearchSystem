﻿namespace AccountsMS.Data.Models.Organization
{
    public class OrganizationModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Hometown { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
