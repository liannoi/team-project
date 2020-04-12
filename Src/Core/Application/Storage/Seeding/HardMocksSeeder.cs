using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TeamProject.Application.Storage.Seeding
{
    public class HardMocksSeeder
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public HardMocksSeeder(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            if (await _roleManager.Roles.AnyAsync(cancellationToken)) return;

            await _roleManager.CreateAsync(new IdentityRole("Administrator"));
            await _roleManager.CreateAsync(new IdentityRole("User"));
        }
    }
}