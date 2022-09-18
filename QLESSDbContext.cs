using Microsoft.EntityFrameworkCore;
using QLess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLess
{
    public class QLESSDbContext : DbContext
    {
        public QLESSDbContext(DbContextOptions<QLESSDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
