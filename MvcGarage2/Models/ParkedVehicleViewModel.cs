using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGarage2.Models
{
    public class ParkedVehicleViewModel
    {
        public ParkedVehicle ParkedVehicle { get; set; }
        public SelectList Colors { get; set; }
        public SelectList Types { get; set; }
    }
}
