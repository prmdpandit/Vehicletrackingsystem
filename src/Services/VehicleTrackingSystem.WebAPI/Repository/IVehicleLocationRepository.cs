using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.WebAPI.Entities;

namespace VehicleTrackingSystem.WebAPI.Repository
{
   public interface IVehicleLocationRepository:IRepository<VehicleLocation>
    {
        Task<VehicleLocation> GetVehicleLocationByDeviceId(Guid deviceId);
    }
}
