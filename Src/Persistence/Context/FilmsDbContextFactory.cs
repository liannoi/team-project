using Microsoft.EntityFrameworkCore;

namespace TeamProject.Persistence.Context
{
    public class FilmsDbContextFactory : DesignTimeDbContextFactoryBase<FilmsDbContext>
    {
        protected override FilmsDbContext CreateNewInstance(DbContextOptions<FilmsDbContext> options)
        {
            return new FilmsDbContext(options);
        }
    }
}