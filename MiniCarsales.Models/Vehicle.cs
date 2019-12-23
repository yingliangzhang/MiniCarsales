using System;
using System.Collections.Generic;
using System.Text;

namespace MiniCarsales.Models
{
    public class Vehicle : IVehicle
    {
        public Vehicle()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Type { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAT { get; set; }
    }
}
