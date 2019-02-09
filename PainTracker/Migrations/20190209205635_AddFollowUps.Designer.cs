﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PainTracker.Models;

namespace PainTracker.Migrations
{
    [DbContext(typeof(TourContext))]
    [Migration("20190209205635_AddFollowUps")]
    partial class AddFollowUps
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PainTracker.Data.FollowUp.FollowUpDTO", b =>
                {
                    b.Property<int>("FollowUpId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateGenerated");

                    b.Property<int?>("FollowUpQuestionQuestionId");

                    b.Property<bool>("NotifyPatientFlag");

                    b.Property<int>("State");

                    b.HasKey("FollowUpId");

                    b.HasIndex("FollowUpQuestionQuestionId");

                    b.ToTable("FollowUpDTO");
                });

            modelBuilder.Entity("PainTracker.Models.FollowUpModels.FollowUpQuestion", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FollowUpDTOFollowUpId");

                    b.Property<int>("FollowUpRefId");

                    b.Property<string>("Question");

                    b.HasKey("QuestionId");

                    b.HasIndex("FollowUpDTOFollowUpId");

                    b.ToTable("FollowUpQuestion");
                });

            modelBuilder.Entity("PainTracker.Models.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("IncludesMeals");

                    b.Property<int>("Length");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<string>("Rating");

                    b.HasKey("Id");

                    b.ToTable("Tour");
                });

            modelBuilder.Entity("PainTracker.Data.FollowUp.FollowUpDTO", b =>
                {
                    b.HasOne("PainTracker.Models.FollowUpModels.FollowUpQuestion", "FollowUpQuestion")
                        .WithMany()
                        .HasForeignKey("FollowUpQuestionQuestionId");
                });

            modelBuilder.Entity("PainTracker.Models.FollowUpModels.FollowUpQuestion", b =>
                {
                    b.HasOne("PainTracker.Data.FollowUp.FollowUpDTO")
                        .WithMany("QuestionId")
                        .HasForeignKey("FollowUpDTOFollowUpId");
                });
#pragma warning restore 612, 618
        }
    }
}
