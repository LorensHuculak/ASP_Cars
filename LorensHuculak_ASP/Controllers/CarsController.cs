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
    public class CarsController : Controller
    {
        private readonly IDatabaseService dbService;

        public CarsController(IDatabaseService db)
        {
            dbService = db;
        }

        // GET: Cars
        [HttpGet("/cars")]
        public IActionResult Index()
        {
            var model = new CarListViewModel { Cars = new List<CarViewModel>() };
            model.Cars.AddRange(dbService.AllCars().Select(ConvertToVM).ToList());
            return View(model);
        }

        [HttpGet("/edit/{id}")]
        public IActionResult Details([FromRoute] int id)
        {
            EditViewModel model;

            var car = dbService.GetCarById(id);

            if (car == null)
            {
                model = new EditViewModel
                {
                    Id = 0,
                    Plate = "",
                    PurchaseDate = DateTime.Now,
                    Owner = "",
                    OwnerId = 0,
                    Brand = "",
                    BrandId = 0
                };
            }
            else
            {
                model = ConvertToEdit(car);
            }

            model.Owners = dbService.AllOwners().Select(x => new SelectListItem
            {
                Text = x.FullName,
                Value = x.Id.ToString()
            }).ToList();

            model.CarTypes = dbService.AllCarTypes().Select(x => new SelectListItem
            {
                Text = x.FullBrand,
                Value = x.Id.ToString()
            }).ToList();

            return View(model);
        }
        
        [HttpPost("/save-car")]
        public IActionResult Save([FromForm] EditViewModel form)
        {
            Car car;
            if (form.Id == 0)
            {
                car = new Car();
            } else {
                car = dbService.GetCarById(form.Id);
            }

            car.LicensePlate = form.Plate;
            car.Owner = dbService.GetOwnerById((int)form.OwnerId.Value);
            car.CarType = dbService.GetCarTypeById((int)form.BrandId.Value);
            dbService.SaveCar(car);

            return Redirect("/Cars");
        }

        [HttpGet("/delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            dbService.DeleteCar(id);
            return Redirect("/Cars");
        }

        protected CarViewModel ConvertToVM(Car car)
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

        protected EditViewModel ConvertToEdit(Car car)
        {
            return new EditViewModel
            {
                Id = car.Id,
                Plate = car.LicensePlate,
                PurchaseDate = car.PurchaseDate,
                Owner = car.Owner.FullName,
                OwnerId = car.Owner.Id,
                Brand = car.CarType.FullBrand,
                BrandId = car.CarType.Id
            };
        }
    }
}
