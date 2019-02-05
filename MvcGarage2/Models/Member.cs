using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGarage2.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //nav collection
        public ICollection<ParkedVehicle> ParkedVehicles { get; set; }
    }
}
