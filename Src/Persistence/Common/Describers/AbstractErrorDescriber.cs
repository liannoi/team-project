using Microsoft.AspNetCore.Identity;

namespace TeamProject.Persistence.Common.Describers
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