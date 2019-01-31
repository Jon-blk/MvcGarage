using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGarage2.Models
{
    public class VehiclePriceViewModel
    {

        public ParkedVehicle ParkedVehicle { get; set; }

        [DataType(DataType.Currency)]
        public float CurrentPrice { get; set; }
    }
}
