using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamProject.Domain.Entities;

namespace TeamProject.Persistence.Context
{
    public class FilmsIdentityContext : IdentityDbContext<AppUser>
    {
        public FilmsIdentityContext(DbContextOptions<FilmsIdentityContext> options) : base(options)
        {
        }
    }
}