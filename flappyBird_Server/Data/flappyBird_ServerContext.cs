using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using flappyBird_Server.Models;

namespace flappyBird_Server.Data
{
    public class flappyBird_ServerContext : DbContext
    {
        public flappyBird_ServerContext (DbContextOptions<flappyBird_ServerContext> options)
            : base(options)
        {
        }

        public DbSet<flappyBird_Server.Models.Score> Score { get; set; } = default!;
    }
}
