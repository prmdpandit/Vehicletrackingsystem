using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTrackingSystem.WebAPI.Entities
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateLocationTimeStamp { get; set; }
    }
}
