using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CoreFoundamentals.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoreFoundamentals.Services
{

    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        
        Restaurant GetId(int id);
        Restaurant Add(Restaurant newRestaurant);
    }
    public class InMemoryRestaurantData:IRestaurantData
    {
        private static IList<Restaurant> _restaurantssList;
        static  InMemoryRestaurantData()
        {
            _restaurantssList = new List<Restaurant>()
            {
                new Restaurant() {Id = 1, Name = "The Vintage"},
                new Restaurant() {Id = 2, Name = "Golden steg"},
                new Restaurant() {Id = 3, Name = "Makarona"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurantssList;
        }

        [HttpGet]
        public Restaurant GetId(int id)
        {
            return _restaurantssList.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurantssList.Max(x => x.Id) + 1;
            _restaurantssList.Add(newRestaurant);
            return newRestaurant;
        }
    }
}