using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TESTFamifedScreens.BLL.Enums
{
    public enum FoodOption
    {
        Geen,
        Standaard,
        [Display(Name = "Koud Buffet")]
        Koud_Buffet,
        [Display(Name = "Warm Buffet")]
        Warm_Buffet
    }
}
