﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGarage2.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        [Display(Name = "Fordonstyp")]
        [Required]
        public string Type { get; set; }

        [Required]
        public float ParkingPrice { get; set; }

        //nav collection
        public ICollection<ParkedVehicle> ParkedVehicles { get; set; }
    }
}
