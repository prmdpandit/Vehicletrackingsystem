using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTrackingSystem.WebAPI.Entities
{
    public class VehicleLocation:BaseEntity
    {        
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; } 
            
        public Guid DeviceID { get; set; }
        
        public List<LocationData> locationData { get; set; }
        public virtual VehicleDevice VehicleDevice { get; set; }
        
    }

    public class LocationData: BaseEntity
    {
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }        
    }
}
