using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using ExploreCalifornia.Models;

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

        //Used for retrieving records for PainDiary/PainEntry/Mood/Interference
        public DbSet<ExploreCalifornia.Models.PainDiary> PainDiary { get; set; }
        public DbSet<ExploreCalifornia.Models.PainEntry> PainEntry { get; set; }
        public DbSet<ExploreCalifornia.Models.Mood> Mood { get; set; }
        public DbSet<ExploreCalifornia.Models.Interference> Interference { get; set; }
    }
}
