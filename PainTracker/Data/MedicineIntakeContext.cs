using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using PainTracker.Models;

namespace PainTracker.Models
{
    public class MedicineIntakeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //To be edited to your own database
                //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ExploreCaliforniaContext-07d0d4d2-781a-4261-bdda-4e2e0a8da355;Trusted_Connection=True;MultipleActiveResultSets=true");
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ExploreCaliforniaContext-cbcf1098-7be9-49ca-a705-8d127e5566bb;Trusted_Connection=True;MultipleActiveResultSets=true"); 
            }
        }

        public MedicineIntakeContext (DbContextOptions<MedicineIntakeContext> options)
            : base(options)
        {
        }

<<<<<<< HEAD
       

        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Prescription> PrescriptionModel { get; set; }
=======
        public MedicineIntakeContext()
        {
        }

        public DbSet<Medicine> MedicineModel { get; set; }
        public DbSet<Instruction> PrescriptionModel { get; set; }
>>>>>>> 5d44be588376843a8b736ba09f776977017c710a
        public DbSet<Image> ImageModel { get; set; }
        public DbSet<Logger> Logger { get; set; }
        //public DbSet<MedicineIntakeEvent> MedicineIntakeEventModel { get; set; }
    }
}
