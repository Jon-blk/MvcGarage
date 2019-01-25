using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGarage2.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Brand { get; set; }
        public string VehicleModel { get; set; }
        public int NumberOfWheels { get; set; }
        public DateTime StartTime { get; set; }
        public VehicleType VehicleType { get; set; }
        public ConsoleColor Color { get; set; }
    }
}
