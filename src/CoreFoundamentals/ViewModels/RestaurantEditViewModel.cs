using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CoreFoundamentals.Entities;

namespace CoreFoundamentals.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Required, MinLength(3)]
        public string  Name { get; set; }
        public CusineType Cusine { get; set; }
    }
}
