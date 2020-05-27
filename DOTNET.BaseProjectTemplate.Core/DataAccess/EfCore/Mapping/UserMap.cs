using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DOTNET.BaseProjectTemplate.Core.Timing;
using DOTNET.BaseProjectTemplate.Core.Utils;
using DOTNET.BaseProjectTemplate.Core.Entities;
using System.Collections.Generic;

namespace DOTNET.BaseProjectTemplate.Core.DataAccess.EfCore.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public PasswordHasher<User> Hasher { get; set; } = new PasswordHasher<User>();

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.Property(b => b.FirstName).HasMaxLength(150);
            builder.Property(b => b.LastName).HasMaxLength(150);
            builder.Property(b => b.MiddleName).HasMaxLength(150);

            SetupAdmin(builder);
        }

        private void SetupAdmin(EntityTypeBuilder<User> builder)
        {
            var user1 = new User
            {
                Id = 1,
                CreationTime = Clock.Now,
                FirstName = "Tester",
                LastName = "User",
                LastLoginDate = Clock.Now,
                Email = "tester@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "tester@gmail.com".ToUpper(),
                UserName = "tester@gmail.com",
                NormalizedUserName = "tester@gmail.com".ToUpper(),
                PasswordHash = Hasher.HashPassword(null, "micr0s0ft_"),
                SecurityStamp = "99ae0c45-d682-4542-9ba7-1281e471916b",
            };

            var users = new List<User>() { user1};

            builder.HasData(users);
        }
    }
}