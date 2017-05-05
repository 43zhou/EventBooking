﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EventBookingSystem.Models;

namespace EventBookingSystem.Data.ApplicationDbContext
{
    [DbContext(typeof(EventBookingSystem.Models.ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("EventBookingSystem.Models.CreatedEvent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacities");

                    b.Property<string>("Category");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Price");

                    b.Property<string>("PromotionalCode");

                    b.Property<string>("StudentNameber");

                    b.Property<string>("Title");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.ToTable("CreatedEvents");
                });

            modelBuilder.Entity("EventBookingSystem.Models.Participation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreatedEventID");

                    b.Property<string>("StudentNumber");

                    b.Property<string>("Title");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.HasIndex("CreatedEventID");

                    b.ToTable("Participations");
                });

            modelBuilder.Entity("EventBookingSystem.Models.Participation", b =>
                {
                    b.HasOne("EventBookingSystem.Models.CreatedEvent", "CreatedEvent")
                        .WithMany()
                        .HasForeignKey("CreatedEventID");
                });
        }
    }
}
