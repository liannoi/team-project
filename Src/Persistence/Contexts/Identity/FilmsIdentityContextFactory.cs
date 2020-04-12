using Microsoft.EntityFrameworkCore;
using TeamProject.Persistence.Common;

namespace TeamProject.Persistence.Contexts.Identity
{
    public class FilmsIdentityContextFactory : DesignTimeDbContextFactoryBase<FilmsIdentityContext>
    {
        protected override FilmsIdentityContext CreateNewInstance(DbContextOptions<FilmsIdentityContext> options)
        {
            return new FilmsIdentityContext(options);
        }
    }
}