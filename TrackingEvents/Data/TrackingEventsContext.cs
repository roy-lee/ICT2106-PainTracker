using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrackingEvents.Models;

namespace TrackingEvents.Models
{
    public class TrackingEventsContext : DbContext
    {

        public TrackingEventsContext()
        {

        }

        public TrackingEventsContext (DbContextOptions<TrackingEventsContext> options)
            : base(options)
        {
        }

        public DbSet<TrackingEvents.Models.Events> Events { get; set; }

        public DbSet<TrackingEvents.Models.PainDiary> PainDiary { get; set; }

        public DbSet<TrackingEvents.Models.Followup> Followup { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TrackingEventsContext-2d0cbd61-d15d-4506-9125-a96333360d49;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
