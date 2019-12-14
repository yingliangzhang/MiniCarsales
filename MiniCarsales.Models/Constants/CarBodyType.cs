using System;
using System.Collections.Generic;
using System.Text;

namespace MiniCarsales.Models.Constants
{
    public static class CarBodyType
    {
        public const string Sedan = "Sedan";
        public const string Hatchback = "Hatchback";

        public static string[] ToArray()
        {
            return new string[] { Sedan, Hatchback };
        }
    }
}
