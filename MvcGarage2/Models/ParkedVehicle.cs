using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGarage2.Models
{
    public class ParkedVehicle
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Registreringsnummer kan inte vara tomt")]
        [Display(Name ="Registreringsnummer")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Märke")]
        public string Brand { get; set; }

        [Display(Name = "Modell")]
        public string VehicleModel { get; set; }

        [Display(Name = "Antal hjul")]
        [Required(ErrorMessage = "Antal hjul måste anges")]
        [Range(1, 8,
        ErrorMessage = "Fordon måste ha mellan {1} och {2} hjul")]
        public int NumberOfWheels { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ankomsttid")]
        public DateTime StartTime { get; set; }

        public int VehicleTypeId { get; set; }
        [Display(Name = "Fordonstyp")]
        public VehicleType VehicleType { get; set; }

        [Display(Name = "Färg")]
        public VehicleColor Color { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
