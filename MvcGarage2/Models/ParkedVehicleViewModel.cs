using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGarage2.Models
{
    public class ParkedVehicleViewModel
    {
        public string VehicleType { get; set; }
        public string RegNbr { get; set; }

        public List<ParkedVehicle> ParkedVehicle { get; set; }
        public SelectList VehicleTypes;

        //[DisplayFormat(DataFormatString = "{0:C2}")]
        //public float CurrentPrice { get; set; }
    }
}
