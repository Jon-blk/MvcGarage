using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGarage2.Models
{
    public class VehiclePriceViewModel
    {
        public ParkedVehicle ParkedVehicle { get; set; }
        public string CurrentPrice { get; set; }
    }
}
