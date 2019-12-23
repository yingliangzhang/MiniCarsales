using MiniCarsales.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MiniCarsales.Models.Constants;

namespace MiniCarsales.Api.Test.Integration
{
    public static class Utilities
    {
        public static void InitializeDbForTests(VehiclesContext db)
        {
            var car1Id = Guid.Parse("e7341f86-28bd-49bc-9509-e23752cfa450");
            var car2Id = Guid.Parse("b27f84a0-6ddb-44e6-8f31-123eca58ecbe");
            var car3Id = Guid.Parse("fdaac995-ea18-41ff-8f16-a200d6ec7a40");

            var cars = new List<Car>()
            {
                new Car
                {
                    Id = car1Id,
                    Make = "Toyota",
                    Model = "Yaris",
                    NumberOfWheels = 4,
                    NumberOfDoors = 5,
                    Engine = "V4",
                    BodyType = CarBodyType.Sedan
                },
                new Car
                {
                    Id = car2Id,
                    Make = "Toyota",
                    Model = "RAV4",
                    NumberOfWheels = 4,
                    NumberOfDoors = 5,
                    Engine = "V6",
                    BodyType = CarBodyType.Hatchback
                },
                new Car
                {
                    Id = car3Id,
                    Make = "Ford",
                    Model = "Ranger",
                    NumberOfWheels = 4,
                    NumberOfDoors = 4,
                    Engine = "V8",
                    BodyType = CarBodyType.Sedan
                }
            };

            db.Cars.AddRange(cars);
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(VehiclesContext db)
        {
            db.Cars.RemoveRange(db.Cars);
            InitializeDbForTests(db);
        }
    }
}
