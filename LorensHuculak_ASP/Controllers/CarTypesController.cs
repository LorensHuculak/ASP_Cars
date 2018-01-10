using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LorensHuculak_ASP.Models;
using LorensHuculak_ASP.Services;
using LorensHuculak_ASP.ViewModels;

namespace LorensHuculak_ASP.Controllers
{
    public class CarTypesController : Controller
    {
        private readonly IDatabaseService dbService;

        public CarTypesController(IDatabaseService db)
        {
            dbService = db;
        }

        // GET: CarTypes
        public IActionResult Index()
        {
            var model = new CarTypeListViewModel { CarTypes = new List<CarTypeViewModel>() };
            model.CarTypes.AddRange(dbService.AllCarTypesWithCars().Select(ConvertToCarType).ToList());
            return View(model);
        }

        protected CarTypeViewModel ConvertToCarType(CarType carType)
        {
            var cars = new List<CarViewModel>();
            cars.AddRange(carType.Cars.Select(ConvertToCar).ToList());

            return new CarTypeViewModel
            {
                Id = carType.Id,
                Brand = carType.FullBrand,
                Cars = cars
            };
        }

        protected CarViewModel ConvertToCar(Car car)
        {
            return new CarViewModel()
            {
                Id = car.Id,
                Plate = car.LicensePlate,
                Owner = car.Owner.FullName,
                Brand = car.CarType.FullBrand,
                BrandName = car.CarType.Brand,
                Model = car.CarType.Model
            };
        }
    }
}
