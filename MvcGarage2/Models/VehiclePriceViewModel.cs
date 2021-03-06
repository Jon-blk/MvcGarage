﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGarage2.Models
{
    public class VehiclePriceViewModel
    {
        public Member Member { get; set; }
        public ParkedVehicle ParkedVehicle { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Kostnad")]
        public float CurrentPrice { get; set; }
        [Display(Name = "Parkerad tid(hh:mm)")]
        public string ParkedMinutes { get; set; }
    }
}
