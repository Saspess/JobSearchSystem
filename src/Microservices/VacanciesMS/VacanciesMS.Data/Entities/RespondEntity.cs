namespace VacanciesMS.Data.Entities
{
    public class RespondEntity : BaseEntity
    {
        public int VacancyId { get; set; }
        public VacancyEntity Vacancy { get; set; } = null!;
        public int EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; } = null!;
    }
}
