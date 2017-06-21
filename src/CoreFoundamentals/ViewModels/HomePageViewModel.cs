using System.Collections.Generic;
using CoreFoundamentals.Entities;

namespace CoreFoundamentals.ViewModels
{
    public class HomePageViewModel
    {
        public string CurrentMessage { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

    }
}