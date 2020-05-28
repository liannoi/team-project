using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace TeamProject.Application.Storage.Seeding
{
    public class SeedingIdentityCommand : IRequest
    {
        public class SeedingIdentityCommandHandler : IRequestHandler<SeedingIdentityCommand>
        {
            private readonly RoleManager<IdentityRole> _roleManager;

            public SeedingIdentityCommandHandler(RoleManager<IdentityRole> roleManager)
            {
                _roleManager = roleManager;
            }

            public async Task<Unit> Handle(SeedingIdentityCommand request, CancellationToken cancellationToken)
            {
                await new HardMocksSeeder(_roleManager).SeedAllAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}