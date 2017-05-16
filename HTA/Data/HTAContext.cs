using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HTA.Models
{
    public class HTAContext : DbContext
    {
        public HTAContext (DbContextOptions<HTAContext> options)
            : base(options)
        {
        }

        public DbSet<HTA.Models.Devotee> Devotee { get; set; }
    }
}
