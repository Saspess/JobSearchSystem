namespace VacanciesMS.Data.Entities
{
    public class VacancyEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int OrganizationId { get; set; }
        public OrganizationEntity Organization { get; set; } = null!;
        public ICollection<RespondEntity> Responds { get; set; }
    }
}
