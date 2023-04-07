namespace VacanciesMS.Data.Entities
{
    public class OrganizationEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public ICollection<VacancyEntity> Vacancies { get; set; }
    }
}
