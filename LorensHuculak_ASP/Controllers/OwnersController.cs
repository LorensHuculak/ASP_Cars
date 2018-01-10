using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LorensHuculak_ASP.Models;
using LorensHuculak_ASP.ViewModels;
using LorensHuculak_ASP.Services;

namespace LorensHuculak_ASP.Controllers
{
    public class OwnersController : Controller
    {
        private readonly IDatabaseService dbService;

        public OwnersController(IDatabaseService db)
        {
            dbService = db;
        }

        // GET: CarTypes
        public IActionResult Index()
        {
            var model = new OwnerListViewModel { Owners = new List<OwnerViewModel>() };
            model.Owners.AddRange(dbService.AllOwnersWithCars().Select(ConvertToOwner).ToList());
            return View(model);
        }

        protected OwnerViewModel ConvertToOwner(Owner owner)
        {
            var cars = new List<CarViewModel>();
            cars.AddRange(owner.Cars.Select(ConvertToCar).ToList());

            return new OwnerViewModel
            {
                Id = owner.Id,
                FullName = owner.FullName,
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
