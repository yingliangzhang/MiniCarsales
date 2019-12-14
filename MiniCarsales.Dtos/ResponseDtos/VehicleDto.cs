using System;
using System.Collections.Generic;
using System.Text;

namespace MiniCarsales.Dtos
{
    public abstract class VehicleDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAT { get; set; }
    }
}
