using Microsoft.EntityFrameworkCore;

namespace TeamProject.Persistence.Context
{
    public class IntervalsDbContextFactory : DesignTimeDbContextFactoryBase<FilmsDbContext>
    {
        protected override FilmsDbContext CreateNewInstance(DbContextOptions<FilmsDbContext> options)
        {
            return new FilmsDbContext(options);
        }
    }
}