using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using flappyBird_Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace flappyBird_Server.Data
{
    public class flappyBird_ServerContext : IdentityDbContext<User>
    {
        public flappyBird_ServerContext (DbContextOptions<flappyBird_ServerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            User u1 = new User
            {
                Id = "6414cd54-1676-424a-86a1-e6bd6e5225c0",
                UserName = "allo",
                Email = "lol@gmail.com",
                NormalizedEmail = "LOL@GMAIL.COM",
                NormalizedUserName = "ALLO"
            };
            u1.PasswordHash = hasher.HashPassword(u1, "Allo!2");
            builder.Entity<User>().HasData(u1);


            builder.Entity<Score>().HasData(new Score()
            {
                Id = 1,
                Pseudo = "allo",
                scoreValue = 1,
                timeInSeconds = "1",
                isPublic = true,
                date = DateTime.Now.ToString()

            });
        }

        public DbSet<flappyBird_Server.Models.Score> Score { get; set; } = default!;
    }
}
