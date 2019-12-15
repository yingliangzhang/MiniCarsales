using System;
using System.Collections.Generic;
using System.Text;

namespace MiniCarsales.Models.Constants
{
    public static class VehicleType
    {
        public const string Car = "Car";
        public const string Boat = "Boat";
        public const string Bike = "Bike";
        public const string Truck = "Truck";

        public static string[] ToArray()
        {
            return new string[] { Car, Boat, Bike, Truck };
        }
    }
}
