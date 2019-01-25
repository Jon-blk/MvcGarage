﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcGarage2.Models;

namespace MvcGarage2.Migrations
{
    [DbContext(typeof(MvcGarage2Context))]
    [Migration("20190125125510_Seed")]
    partial class Seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcGarage2.Models.ParkedVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand");

                    b.Property<int>("Color");

                    b.Property<int>("NumberOfWheels");

                    b.Property<string>("RegistrationNumber");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("VehicleModel");

                    b.Property<int>("VehicleType");

                    b.HasKey("Id");

                    b.ToTable("ParkedVehicle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Volvo",
                            Color = 0,
                            NumberOfWheels = 4,
                            RegistrationNumber = "ABC123",
                            StartTime = new DateTime(2019, 1, 10, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            VehicleModel = "V70",
                            VehicleType = 0
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Volvo",
                            Color = 9,
                            NumberOfWheels = 4,
                            RegistrationNumber = "BCD123",
                            StartTime = new DateTime(2019, 1, 10, 12, 10, 0, 0, DateTimeKind.Unspecified),
                            VehicleModel = "S80",
                            VehicleType = 0
                        },
                        new
                        {
                            Id = 3,
                            Brand = "SAAB",
                            Color = 7,
                            NumberOfWheels = 4,
                            RegistrationNumber = "CDE123",
                            StartTime = new DateTime(2019, 1, 10, 12, 20, 0, 0, DateTimeKind.Unspecified),
                            VehicleModel = "900",
                            VehicleType = 0
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Yamaha",
                            Color = 0,
                            NumberOfWheels = 2,
                            RegistrationNumber = "ABC001",
                            StartTime = new DateTime(2019, 1, 10, 12, 30, 0, 0, DateTimeKind.Unspecified),
                            VehicleModel = "ZX750",
                            VehicleType = 1
                        },
                        new
                        {
                            Id = 5,
                            Brand = "BMW",
                            Color = 9,
                            NumberOfWheels = 2,
                            RegistrationNumber = "ABC002",
                            StartTime = new DateTime(2019, 1, 10, 12, 40, 0, 0, DateTimeKind.Unspecified),
                            VehicleModel = "CC750",
                            VehicleType = 1
                        },
                        new
                        {
                            Id = 6,
                            Brand = "BMW",
                            Color = 15,
                            NumberOfWheels = 2,
                            RegistrationNumber = "ABC003",
                            StartTime = new DateTime(2019, 1, 10, 12, 50, 0, 0, DateTimeKind.Unspecified),
                            VehicleModel = "CC900",
                            VehicleType = 1
                        },
                        new
                        {
                            Id = 7,
                            Brand = "Scania",
                            Color = 15,
                            NumberOfWheels = 6,
                            RegistrationNumber = "AOO111",
                            StartTime = new DateTime(2019, 1, 10, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            VehicleModel = "1200 KK",
                            VehicleType = 2
                        },
                        new
                        {
                            Id = 8,
                            Brand = "Volvo",
                            Color = 12,
                            NumberOfWheels = 6,
                            RegistrationNumber = "AOO222",
                            StartTime = new DateTime(2019, 1, 10, 13, 10, 0, 0, DateTimeKind.Unspecified),
                            VehicleModel = "1200 KK",
                            VehicleType = 2
                        },
                        new
                        {
                            Id = 9,
                            Brand = "Mercedes",
                            Color = 15,
                            NumberOfWheels = 4,
                            RegistrationNumber = "AOO333",
                            StartTime = new DateTime(2019, 1, 10, 13, 20, 0, 0, DateTimeKind.Unspecified),
                            VehicleModel = "1200 KK",
                            VehicleType = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
