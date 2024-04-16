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
            User u2 = new User
            {
                Id = "6414cd54-1776-424a-86a1-e6bd6e5225c0",
                UserName = "allo2",
                Email = "ol@gmail.com",
                NormalizedEmail = "OL@GMAIL.COM",
                NormalizedUserName = "ALLO2"
            };
            u2.PasswordHash = hasher.HashPassword(u2, "Allo!2");
            builder.Entity<User>().HasData(u1, u2);


            builder.Entity<Score>().HasData(new
            {
                Id = 1,
                Pseudo = "allo",
                scoreValue = 1,
                timeInSeconds = "1",
                isPublic = true,
                date = DateTime.Now.ToString()
            }, new
            {
                Id = 2,
                Pseudo = "allo",
                scoreValue = 133,
                timeInSeconds = "111",
                isPublic = false,
                date = DateTime.Now.ToString()
            }, new
            {
                Id = 3,
                Pseudo = "allo",
                scoreValue = 34,
                timeInSeconds = "13",
                isPublic = false,
                date = DateTime.Now.ToString()
            }, new
            {
                Id = 4,
                Pseudo = "allo2",
                scoreValue = 18,
                timeInSeconds = "123",
                isPublic = true,
                date = DateTime.Now.ToString()
            });
        }

        public DbSet<flappyBird_Server.Models.Score> Score { get; set; } = default!;
    }
}
