using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcGarage2.Models
{
    public class MvcGarage2Context : DbContext
    {
        public MvcGarage2Context (DbContextOptions<MvcGarage2Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ParkedVehicle>()
               .HasData(
                new { Id = 1, RegistrationNumber = "ABC123", Brand = "Volvo", VehicleModel = "V70", NumberOfWheels = 4, StartTime = DateTime.Parse("2019-01-10 12:00"), VehicleType = (VehicleType)0, Color = (VehicleColor)0 },
                new { Id = 2, RegistrationNumber = "BCD123", Brand = "Volvo", VehicleModel = "S80", NumberOfWheels = 4, StartTime = DateTime.Parse("2019-01-10 12:10"), VehicleType = (VehicleType)0, Color = (VehicleColor)9 },
                new { Id = 3, RegistrationNumber = "CDE123", Brand = "SAAB", VehicleModel = "900", NumberOfWheels = 4, StartTime = DateTime.Parse("2019-01-10 12:20"), VehicleType = (VehicleType)0, Color = (VehicleColor)7 },

                new { Id = 4, RegistrationNumber = "ABC001", Brand = "Yamaha", VehicleModel = "ZX750", NumberOfWheels = 2, StartTime = DateTime.Parse("2019-01-10 12:30"), VehicleType = (VehicleType)1, Color = (VehicleColor)0 },
                new { Id = 5, RegistrationNumber = "ABC002", Brand = "BMW", VehicleModel = "CC750", NumberOfWheels = 2, StartTime = DateTime.Parse("2019-01-10 12:40"), VehicleType = (VehicleType)1, Color = (VehicleColor)9 },
                new { Id = 6, RegistrationNumber = "ABC003", Brand = "BMW", VehicleModel = "CC900", NumberOfWheels = 2, StartTime = DateTime.Parse("2019-01-10 12:50"), VehicleType = (VehicleType)1, Color = (VehicleColor)15 },

                new { Id = 7, RegistrationNumber = "AOO111", Brand = "Scania", VehicleModel = "1200 KK", NumberOfWheels = 6, StartTime = DateTime.Parse("2019-01-10 13:00"), VehicleType = (VehicleType)2, Color = (VehicleColor)15 },
                new { Id = 8, RegistrationNumber = "AOO222", Brand = "Volvo", VehicleModel = "1200 KK", NumberOfWheels = 6, StartTime = DateTime.Parse("2019-01-10 13:10"), VehicleType = (VehicleType)2, Color = (VehicleColor)12 },
                new { Id = 9, RegistrationNumber = "AOO333", Brand = "Mercedes", VehicleModel = "1200 KK", NumberOfWheels = 4, StartTime = DateTime.Parse("2019-01-10 13:20"), VehicleType = (VehicleType)2, Color = (VehicleColor)15 }
                );
       }

        public DbSet<MvcGarage2.Models.ParkedVehicle> ParkedVehicle { get; set; }
    }
}
