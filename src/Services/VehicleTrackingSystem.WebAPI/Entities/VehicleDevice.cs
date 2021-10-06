using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTrackingSystem.WebAPI.Entities
{
    public class VehicleDevice:BaseEntity
    {     
        public string DeviceName { get; set; }
        public int VehicleID { get; set; }
        public virtual VehicleRegistration Vehicle { get; set; }       
        public virtual ICollection<VehicleLocation> Locations { get; set; }
    }
}
