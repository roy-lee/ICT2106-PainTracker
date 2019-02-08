using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace PainTracker.Models
{
    public class PainTrackerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PainTrackerContext-07d0d4d2-781a-4261-bdda-4e2e0a8da355;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public PainTrackerContext()
        {
        }

        public PainTrackerContext (DbContextOptions<PainTrackerContext> options)
            : base(options)
        {
        }

        public PainTrackerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PainTracker.Models.Tour> Tour { get; set; }
    }
}
