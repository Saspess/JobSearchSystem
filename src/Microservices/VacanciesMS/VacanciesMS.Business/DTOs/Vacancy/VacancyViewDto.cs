namespace VacanciesMS.Business.DTOs.Vacancy
{
    public class VacancyViewDto
    {
        public int Id { get; set; }
        public int OrganizationName { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
