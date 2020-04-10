using Microsoft.EntityFrameworkCore;
using TeamProject.Domain.Entities.Identity.Roles;

namespace TeamProject.Application.Common.Interfaces
{
    public interface IFilmsIdentityContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
    }
}