namespace VacanciesMS.Business.DTOs.Respond
{
    public class RespondViewDto
    {
        public int Id { get; set; }
        public string VacancyName { get; set; } = null!;
        public string EmployeeFirstName { get; set; } = null!;
        public string EmployeeLastName { get; set; } = null!;
    }
}
