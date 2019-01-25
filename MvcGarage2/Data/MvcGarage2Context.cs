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

        public DbSet<MvcGarage2.Models.ParkedVehicle> ParkedVehicle { get; set; }
    }
}
