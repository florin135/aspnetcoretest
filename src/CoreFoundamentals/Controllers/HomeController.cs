using System;
using CoreFoundamentals.Entities;
using CoreFoundamentals.Services;
using CoreFoundamentals.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CoreFoundamentals.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private readonly IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetGreetintg();
            //return new ObjectResult(model);
            return View(model);
        }

        public IActionResult Details(int id)
        {
            Restaurant model = _restaurantData.GetId(id);
            if (model == null)
            {
             return   RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant();
                newRestaurant.Cusine = model.Cusine;
                newRestaurant.Name = model.Name;
                _restaurantData.Add(newRestaurant);
                //return View("Details", newRestaurant);
                return RedirectToAction("Details", new {id = newRestaurant.Id});
            }
            else
            {
                return View();
            }

        }
    }
}