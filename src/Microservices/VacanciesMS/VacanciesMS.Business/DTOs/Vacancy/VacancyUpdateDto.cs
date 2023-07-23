namespace VacanciesMS.Business.DTOs.Vacancy
{
    public class VacancyUpdateDto
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
