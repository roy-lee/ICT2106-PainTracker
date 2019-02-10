﻿using System;
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
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ExploreCaliforniaContext-07d0d4d2-781a-4261-bdda-4e2e0a8da355;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public MedicineIntakeContext()
        {
        }

        public MedicineIntakeContext (DbContextOptions<MedicineIntakeContext> options)
            : base(options)
        {
        }

        public MedicineIntakeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Medicine> MedicineModel { get; set; }
        public DbSet<Prescription> PrescriptionModel { get; set; }
        public DbSet<Image> ImageModel { get; set; }
        public DbSet<Logger> Logger { get; set; }
        //public DbSet<MedicineIntakeEvent> MedicineIntakeEventModel { get; set; }
    }
}
