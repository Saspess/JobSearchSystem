namespace IdentityMS.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
