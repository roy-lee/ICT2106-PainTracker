﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrackingEvents.Models;

namespace TrackingEvents.Migrations
{
    [DbContext(typeof(TrackingEventsContext))]
    partial class TrackingEventsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrackingEvents.Models.Events", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("eventDesc");

                    b.Property<string>("eventType");

                    b.Property<int?>("followupModuleId");

                    b.Property<int?>("painDiaryModuleId");

                    b.HasKey("Id");

                    b.HasIndex("followupModuleId");

                    b.HasIndex("painDiaryModuleId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("TrackingEvents.Models.Followup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dateGenerated");

                    b.Property<string>("followupTitle");

                    b.HasKey("Id");

                    b.ToTable("Followup");
                });

            modelBuilder.Entity("TrackingEvents.Models.PainDiary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("eventDate");

                    b.Property<string>("eventName");

                    b.HasKey("Id");

                    b.ToTable("PainDiary");
                });

            modelBuilder.Entity("TrackingEvents.Models.Events", b =>
                {
                    b.HasOne("TrackingEvents.Models.Followup", "followupModule")
                        .WithMany()
                        .HasForeignKey("followupModuleId");

                    b.HasOne("TrackingEvents.Models.PainDiary", "painDiaryModule")
                        .WithMany()
                        .HasForeignKey("painDiaryModuleId");
                });
#pragma warning restore 612, 618
        }
    }
}
