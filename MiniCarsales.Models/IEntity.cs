using System;
using System.Collections.Generic;
using System.Text;

namespace MiniCarsales.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAT { get; set; }
    }
}
