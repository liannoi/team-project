namespace TeamProject.Domain.Entities.Identity.Roles
{
    public class User
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }

        public AppUser Identity { get; set; }
    }
}