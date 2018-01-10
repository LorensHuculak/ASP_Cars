using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LorensHuculak_ASP.Models;
using LorensHuculak_ASP.DB;
using Microsoft.EntityFrameworkCore;

namespace LorensHuculak_ASP.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly EntityContext entityContext;

        public DatabaseService(EntityContext ec)
        {
            entityContext = ec;
        }

        public List<Car> AllCars()
        {
            return entityContext.Cars.Include(c => c.CarType).Include(c => c.Owner).ToList();
        }

        public List<CarType> AllCarTypes()
        {
            return entityContext.CarTypes.ToList();
        }

        public List<CarType> AllCarTypesWithCars()
        {
            return entityContext.CarTypes.Include(c => c.Cars).ThenInclude(c => c.Owner).ToList();
        }

        public List<Owner> AllOwners()
        {
            return entityContext.Owners.ToList();
        }

        public List<Owner> AllOwnersWithCars()
        {
            return entityContext.Owners.Include(c => c.Cars).ThenInclude(c => c.CarType).ToList();
        }

        public Car OnlyCar(int id)
        {
            return entityContext.Cars.Find(id);
        }

        public void DeleteCar(int id)
        {
            var car = OnlyCar(id);
            if (car != null)
            {
                entityContext.Cars.Remove(car);
                entityContext.SaveChanges();
            }
        }

        public CarType GetCarTypeById(int id)
        {
            return entityContext.CarTypes.Find(id);
        }

        public Owner GetOwnerById(int id)
        {
            return entityContext.Owners.Find(id);
        }

        public void SaveCar(Car car)
        {
            if (car.Id == 0)
            {
                entityContext.Cars.Add(car);
            }
            else
            {
                entityContext.Cars.Update(car);
            }

            entityContext.SaveChanges();
        }

        public Car GetCarById(int id)
        {
            return entityContext.Cars.Include(c => c.Owner).Include(c => c.CarType).FirstOrDefault(c => c.Id == id);
        }
    }
}
