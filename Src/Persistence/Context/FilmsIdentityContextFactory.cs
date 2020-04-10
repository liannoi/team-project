using Microsoft.EntityFrameworkCore;

namespace TeamProject.Persistence.Context
{
    public class FilmsIdentityContextFactory : DesignTimeDbContextFactoryBase<FilmsIdentityContext>
    {
        protected override FilmsIdentityContext CreateNewInstance(DbContextOptions<FilmsIdentityContext> options)
        {
            return new FilmsIdentityContext(options);
        }
    }
}