using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTrackingSystem.WebAPI.Entities
{
    public class VehicleRegistration:BaseEntity
    {     

        [Required(ErrorMessage = "Please Vehicle Name"), MaxLength(30)]
        public string VehicleName { get; set; }

        [Required(ErrorMessage = "Please Vehicle Register Number"), MaxLength(20)]
        public string VehicleRegisterNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateTimeStamp { get; set; }        
        public string EmailId { get; set; }
        public Dictionary<string, string> ExtKeyValues { get; set; }
    }
}
