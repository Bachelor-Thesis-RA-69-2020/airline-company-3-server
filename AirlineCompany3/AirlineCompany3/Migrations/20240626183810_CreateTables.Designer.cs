﻿// <auto-generated />
using System;
using AirlineCompany3.Repository.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirlineCompany3.Migrations
{
    [DbContext(typeof(ServerDatabaseContext))]
    [Migration("20240626183810_CreateTables")]
    partial class CreateTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirlineCompany3.Model.Domain.Airport", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Continent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ElevationMeters")
                        .HasColumnType("real");

                    b.Property<string>("Iata")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("LatitudeDegrees")
                        .HasColumnType("real");

                    b.Property<float>("LongitudeDegrees")
                        .HasColumnType("real");

                    b.Property<string>("Municipality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("AirlineCompany3.Model.Domain.Flight", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BaggageGuidelines")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("EndingPointId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("KidsDiscount")
                        .HasColumnType("real");

                    b.Property<DateTime>("ScheduledArrival")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ScheduledDeparture")
                        .HasColumnType("datetime2");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("StartingPointId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TravelTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EndingPointId");

                    b.HasIndex("StartingPointId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AirlineCompany3.Model.Domain.Flight", b =>
                {
                    b.HasOne("AirlineCompany3.Model.Domain.Airport", "EndingPoint")
                        .WithMany()
                        .HasForeignKey("EndingPointId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AirlineCompany3.Model.Domain.Airport", "StartingPoint")
                        .WithMany()
                        .HasForeignKey("StartingPointId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EndingPoint");

                    b.Navigation("StartingPoint");
                });
#pragma warning restore 612, 618
        }
    }
}
