﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(DoctorsDbContext))]
    [Migration("20250207091003_GetAllDoctors-storedProcedure")]
    partial class GetAllDoctorsstoredProcedure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.City", b =>
                {
                    b.Property<Guid>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities", (string)null);

                    b.HasData(
                        new
                        {
                            CityId = new Guid("d5a458f1-0c2a-4979-8369-79e5cb1eaf8e"),
                            CityName = "New York"
                        },
                        new
                        {
                            CityId = new Guid("ad7a5e2b-79ef-4237-b3ad-3f1e31f24a6f"),
                            CityName = "Los Angeles"
                        },
                        new
                        {
                            CityId = new Guid("c9b9e1dc-ded7-4a11-bdf4-37251f1d4ae1"),
                            CityName = "Chicago"
                        },
                        new
                        {
                            CityId = new Guid("74a72b9b-b0b8-487b-86d8-d1ad8b3ecb73"),
                            CityName = "Houston"
                        });
                });

            modelBuilder.Entity("Entities.Doctor", b =>
                {
                    b.Property<Guid>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CityName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("ExaminationPrice")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DoctorId");

                    b.HasIndex("CityId");

                    b.ToTable("Doctors", (string)null);

                    b.HasData(
                        new
                        {
                            DoctorId = new Guid("6f9619ff-8b86-d011-b42d-00cf4fc964ff"),
                            Address = "123 Main Street, New York, NY 10001",
                            CityId = new Guid("d5a458f1-0c2a-4979-8369-79e5cb1eaf8e"),
                            CityName = "New York",
                            DoctorName = "Dr. John Smith",
                            ExaminationPrice = 150,
                            PhoneNumber = "+1-555-123-4567",
                            Specialization = "Cardiologist"
                        },
                        new
                        {
                            DoctorId = new Guid("9c2e7f52-d3df-4fa3-b646-1dd93b467f94"),
                            Address = "456 Sunset Blvd, Los Angeles, CA 90028",
                            CityId = new Guid("ad7a5e2b-79ef-4237-b3ad-3f1e31f24a6f"),
                            CityName = "Los Angeles",
                            DoctorName = "Dr. Emily Davis",
                            ExaminationPrice = 200,
                            PhoneNumber = "+1-555-654-3210",
                            Specialization = "Dermatologist"
                        },
                        new
                        {
                            DoctorId = new Guid("de305d54-75b4-431b-adb2-eb6b9e546013"),
                            Address = "789 Windy City Ave, Chicago, IL 60616",
                            CityId = new Guid("c9b9e1dc-ded7-4a11-bdf4-37251f1d4ae1"),
                            CityName = "Chicago",
                            DoctorName = "Dr. Sarah Johnson",
                            ExaminationPrice = 250,
                            PhoneNumber = "+1-555-987-6543",
                            Specialization = "Neurologist"
                        },
                        new
                        {
                            DoctorId = new Guid("98d076c5-6528-4b4f-90d0-d01f5cd3f004"),
                            Address = "321 Lone Star Rd, Houston, TX 77002",
                            CityId = new Guid("74a72b9b-b0b8-487b-86d8-d1ad8b3ecb73"),
                            CityName = "Houston",
                            DoctorName = "Dr. Michael Brown",
                            ExaminationPrice = 180,
                            PhoneNumber = "010000",
                            Specialization = "Pediatrician"
                        });
                });

            modelBuilder.Entity("Entities.Doctor", b =>
                {
                    b.HasOne("Entities.City", "City")
                        .WithMany("Doctors")
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Entities.City", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
