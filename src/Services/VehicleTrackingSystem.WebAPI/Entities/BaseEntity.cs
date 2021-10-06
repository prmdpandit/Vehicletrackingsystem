using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTrackingSystem.WebAPI.Entities
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateLocationTimeStamp { get; set; } = DateTime.Now;        
    }
}
