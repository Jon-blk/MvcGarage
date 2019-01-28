using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGarage2.Models
{
    public enum VehicleColor
    {
        [Display(Name = "Svart")]
        Black,
        [Display(Name = "Mörkblå")]
        DarkBlue,
        [Display(Name = "Mörkgrön")]
        DarkGreen,
        [Display(Name = "Mörkröd")]
        DarkRed,
        [Display(Name = "Mörkgul")]
        DarkYellow,
        [Display(Name = "Grå")]
        Grey,
        [Display(Name = "Mörkgrå")]
        DarkGrey,
        [Display(Name = "Blå")]
        Blue,
        [Display(Name = "Grön")]
        Green,
        [Display(Name = "Röd")]
        Red,
        [Display(Name = "Gul")]
        Yellow,
        [Display(Name = "Vit")]
        White,
        [Display(Name = "Silver")]
        Silver,
        [Display(Name = "Guld")]
        Gold,
    }
}
