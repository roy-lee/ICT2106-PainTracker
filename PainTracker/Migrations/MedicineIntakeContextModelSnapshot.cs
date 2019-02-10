﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PainTracker.Models;

namespace PainTracker.Migrations
{
    [DbContext(typeof(MedicineIntakeContext))]
    partial class MedicineIntakeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PainTracker.Models.Image", b =>
                {
                    b.Property<int>("ImgID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Img");

                    b.HasKey("ImgID");

                    b.ToTable("ImageModel");
                });

            modelBuilder.Entity("PainTracker.Models.Logger", b =>
                {
                    b.Property<int>("LogID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Dosage");

                    b.Property<DateTime>("ExpiryDate");

                    b.Property<DateTime>("IssuedDate");

                    b.HasKey("LogID");

                    b.ToTable("Logger");
                });

            modelBuilder.Entity("PainTracker.Models.Medicine", b =>
                {
                    b.Property<int>("MedID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MedDescription");

                    b.Property<string>("MedName")
                        .IsRequired();

                    b.Property<string>("MedType")
                        .IsRequired();

                    b.HasKey("MedID");

                    b.ToTable("MedicineModel");
                });

            modelBuilder.Entity("PainTracker.Models.Prescription", b =>
                {
                    b.Property<int>("PrescriptionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Dosage");

                    b.Property<int>("Frequency");

                    b.HasKey("PrescriptionID");

                    b.ToTable("PrescriptionModel");
                });
#pragma warning restore 612, 618
        }
    }
}
