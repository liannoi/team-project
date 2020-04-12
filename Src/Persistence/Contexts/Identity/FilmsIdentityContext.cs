using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamProject.Domain.Entities.Identity;

namespace TeamProject.Persistence.Contexts.Identity
{
    public class FilmsIdentityContext : IdentityDbContext<AppUser>
    {
        public FilmsIdentityContext(DbContextOptions<FilmsIdentityContext> options) : base(options)
        {
        }
    }
}