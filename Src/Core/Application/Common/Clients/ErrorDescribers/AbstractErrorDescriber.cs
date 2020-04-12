using Microsoft.AspNetCore.Identity;

namespace TeamProject.Application.Common.Clients.ErrorDescribers
{
    public class AbstractErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = "A user with this name is already registered."
            };
        }
    }
}