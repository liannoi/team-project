namespace TeamProject.Domain.Entities.Identity.Roles
{
    public class Administrator
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }

        public AppUser Identity { get; set; }
    }
}