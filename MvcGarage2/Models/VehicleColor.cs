using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGarage2.Models
{
    public enum VehicleColor
    {
        [Display(Name = "Brun")]
        Brown,
        [Display(Name = "Blå")]
        Blue,
        [Display(Name = "Grå")]
        Grey,
        [Display(Name = "Grön")]
        Green,
        [Display(Name = "Gul")]
        Yellow,
        [Display(Name = "Guld")]
        Gold,
        [Display(Name = "Lila")]
        Purple,
        [Display(Name = "Mörkblå")]
        DarkBlue,
        [Display(Name = "Mörkgrå")]
        DarkGrey,
        [Display(Name = "Mörkgrön")]
        DarkGreen,
        [Display(Name = "Mörkgul")]
        DarkYellow,
        [Display(Name = "Mörkröd")]
        DarkRed,
        [Display(Name = "Rosa")]
        Pink,
        [Display(Name = "Röd")]
        Red,
        [Display(Name = "Silver")]
        Silver,
        [Display(Name = "Svart")]
        Black,
        [Display(Name = "Vit")]
        White,
    }
}
