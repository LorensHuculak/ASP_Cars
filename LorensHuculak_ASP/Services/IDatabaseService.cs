using LorensHuculak_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LorensHuculak_ASP.Services
{
    public interface IDatabaseService
    {
        // Cars
        List<Car> AllCars();
        Car GetCarById(int id);
        void SaveCar(Car car);
        void DeleteCar(int id);

        // Owner
        List<Owner> AllOwners();
        List<Owner> AllOwnersWithCars();
        Owner GetOwnerById(int id);

        // CarType
        List<CarType> AllCarTypes();
        List<CarType> AllCarTypesWithCars();
        CarType GetCarTypeById(int id);
    }
}
