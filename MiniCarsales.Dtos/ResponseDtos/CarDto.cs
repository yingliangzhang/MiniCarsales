using System;


namespace MiniCarsales.Dtos
{
    public class CarDto : VehicleDto
    {
        public int NumberOfWheels { get; set; }
        public int NumberOfDoors { get; set; }
        public string Engine { get; set; }
        public string BodyType { get; set; }
    }
}
