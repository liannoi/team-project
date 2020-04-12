using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TeamProject.Domain.Entities.Identity;

namespace TeamProject.Application.Storage.Seeding
{
    public class SeedingIdentityCommand : IRequest
    {
        public class SeedingIdentityCommandHandler : IRequestHandler<SeedingIdentityCommand>
        {
            private readonly IdentityDbContext<AppUser> _identityContext;

            public SeedingIdentityCommandHandler(IdentityDbContext<AppUser> identityContext)
            {
                _identityContext = identityContext;
            }

            public async Task<Unit> Handle(SeedingIdentityCommand request, CancellationToken cancellationToken)
            {
                await new MocksSeeder(_identityContext).SeedAllAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}