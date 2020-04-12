using Microsoft.EntityFrameworkCore;
using TeamProject.Persistence.Common;

namespace TeamProject.Persistence.Contexts.Core
{
    public class FilmsDbContextFactory : DesignTimeDbContextFactoryBase<FilmsDbContext>
    {
        protected override FilmsDbContext CreateNewInstance(DbContextOptions<FilmsDbContext> options)
        {
            return new FilmsDbContext(options);
        }
    }
}