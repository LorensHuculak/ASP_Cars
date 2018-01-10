using LorensHuculak_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LorensHuculak_ASP.DB
{
    public class Create
    {
        private static Random random = new Random();

        public static void CreateDatabase(EntityContext entityContext)
        {
            entityContext.Database.EnsureCreated();

            var owners = new List<Owner>
            {
                new Owner() {FirstName = "No", Name = "Owner"},
                new Owner() {FirstName = "Lorens", Name = "Huculak"},
                new Owner() {FirstName = "Michael", Name = "Jackson"},
                new Owner() {FirstName = "Bill", Name = "Gates"},
                 new Owner() {FirstName = "Vitalik", Name = "Buterin"}
            };

            var carTypes = new List<CarType>
            {
                new CarType() {Model = "X6", Brand = "BMW"},
                new CarType() {Model = "Aventador", Brand = "Lamborghini"},
                new CarType() {Model = "C4", Brand = "Citroën"},
                new CarType() {Model = "GLE", Brand = "Mercedes"},
            };

            var cars = new List<Car>();

            List<string> colors = new List<string> {
                "Black",
                "Silver",
                "White",
                "Blue",
                "Red",
                "Yellow",
                "Green",
                "Gold"
            };

            for (var i = 0; i < 15; i++)
            {
                Random rnd = new Random();

                CarType carType = carTypes[random.Next(0, 4)];
                Owner owner = owners[random.Next(1, 5)];
                string color = colors[random.Next(0, 8)];

                cars.Add(new Car { Color = color, PurchaseDate = new DateTime(2017, 11, 20, 09, 08, 06), LicensePlate = RandomString(6), CarType = carType, Owner = owner });
            }

            entityContext.Owners.AddRange(owners);
            entityContext.CarTypes.AddRange(carTypes);
            entityContext.Cars.AddRange(cars);
            entityContext.SaveChanges();
        }

        public static string RandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
