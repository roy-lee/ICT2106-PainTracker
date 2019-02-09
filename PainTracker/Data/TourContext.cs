using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PainTracker.Data.FollowUp;
using PainTracker.Models.FollowUpModels;

namespace PainTracker.Models
{
    public class TourContext : DbContext
    {
        public TourContext (DbContextOptions<TourContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //(localdb)\MSSQLLocalDB
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database = TourContext-a368ca6e-3728-448b-92bb-ce6034c48ed8; Trusted_Connection = True;");
        }

        public DbSet<FollowUpDTO> FollowUpDTO { get; set; }

        public DbSet<PainTracker.Models.Tour> Tour { get; set; }
    }
}
