﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcGarage2.Models;

namespace MvcGarage2.Migrations
{
    [DbContext(typeof(MvcGarage2Context))]
    partial class MvcGarage2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                });
#pragma warning restore 612, 618
        }
    }
}
