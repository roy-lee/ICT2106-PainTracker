using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PainTracker.Models
{
    public class TourContext : DbContext
    {
        public TourContext (DbContextOptions<TourContext> options)
            : base(options)
        {
        }

        public DbSet<PainTracker.Models.Tour> Tour { get; set; }
    }
}
