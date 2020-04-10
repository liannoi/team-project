using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Domain.Entities.Identity;
using TeamProject.Domain.Entities.Identity.Roles;

namespace TeamProject.Persistence.Context
{
    public class FilmsIdentityContext : IdentityDbContext<AppUser>, IFilmsIdentityContext
    {
        public FilmsIdentityContext(DbContextOptions<FilmsIdentityContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
    }
}