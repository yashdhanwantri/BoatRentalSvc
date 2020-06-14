﻿// <auto-generated />
using System;
using BoatRentalSvc.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BoatRentalSvc.Migrations
{
    [DbContext(typeof(BoatDbContext))]
    [Migration("20200614173914_PropertyUpdateBoatRental")]
    partial class PropertyUpdateBoatRental
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BoatRentalSvc.Boat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BoatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("HourlyRate")
                        .HasColumnType("decimal(10,4)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Boats");
                });

            modelBuilder.Entity("BoatRentalSvc.Models.BoatRental", b =>
                {
                    b.Property<int>("RentalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoatId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("RentalId");

                    b.HasIndex("BoatId");

                    b.ToTable("BoatRentals");
                });

            modelBuilder.Entity("BoatRentalSvc.Models.BoatRental", b =>
                {
                    b.HasOne("BoatRentalSvc.Boat", "Boat")
                        .WithMany("BoatRentals")
                        .HasForeignKey("BoatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}