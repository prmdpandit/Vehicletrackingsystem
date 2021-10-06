using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTrackingSystem.WebAPI.Services.Model
{
    public class GMapResponseModel
    {
        public Result[] results { get; set; }
        public string status { get; set; }
    }
    public class Result
    {
        public Address_Components[] address_components { get; set; }
    }

    public class Address_Components
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }
}
