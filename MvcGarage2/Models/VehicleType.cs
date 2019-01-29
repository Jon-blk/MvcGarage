using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGarage2.Models
{
    public enum VehicleType
    {
        [Display(Name = "Bil")]
        Car,
        [Display(Name = "Motorcykel")]
        Motorcycle,
        [Display(Name = "Buss")]
        Bus
    }
}
