using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace ExploreCalifornia.Models
{
    public class ExploreCaliforniaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ExploreCaliforniaContext-07d0d4d2-781a-4261-bdda-4e2e0a8da355;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public ExploreCaliforniaContext()
        {
        }

        public ExploreCaliforniaContext (DbContextOptions<ExploreCaliforniaContext> options)
            : base(options)
        {
        }

        public ExploreCaliforniaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ExploreCalifornia.Models.Tour> Tour { get; set; }
    }
}
