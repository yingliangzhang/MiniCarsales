using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniCarsales.Models
{
    public class Entity : IEntity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAT { get; set; }
    }
}
