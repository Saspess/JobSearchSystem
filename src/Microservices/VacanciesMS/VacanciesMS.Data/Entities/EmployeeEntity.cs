namespace VacanciesMS.Data.Entities
{
    public class EmployeeEntity : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public ICollection<RespondEntity> Responds { get; set; }
    }
}
