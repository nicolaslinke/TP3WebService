using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using flappyBird_Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace flappyBird_Server.Data
{
    public class flappyBird_ServerContext : IdentityDbContext<User>
    {
        public flappyBird_ServerContext (DbContextOptions<flappyBird_ServerContext> options)
            : base(options)
        {
        }

        public DbSet<flappyBird_Server.Models.Score> Score { get; set; } = default!;
    }
}
