using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamProject.Domain.Entities.Identity;

namespace TeamProject.Application.Storage.Seeding
{
    public class MocksSeeder
    {
        private readonly IdentityDbContext<AppUser> _identityContext;

        public MocksSeeder(IdentityDbContext<AppUser> identityContext)
        {
            _identityContext = identityContext;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            if (!await _identityContext.Users.AnyAsync(cancellationToken))
                await _identityContext.Users.AddRangeAsync(new AppUser
                {
                    Email = "user-as-user@mail.com",
                    UserName = "user-as-user@mail.com",
                    PasswordHash = HashPassword("q1w2Q!W@")
                }, new AppUser
                {
                    Email = "user-as-admin@mail.com",
                    UserName = "user-as-admin@mail.com",
                    PasswordHash = HashPassword("q1w2Q!W@!")
                });

            await _identityContext.SaveChangesAsync(cancellationToken);
        }

        private static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null) throw new ArgumentNullException(nameof(password));

            using (var bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }

            var dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);

            return Convert.ToBase64String(dst);
        }
    }
}