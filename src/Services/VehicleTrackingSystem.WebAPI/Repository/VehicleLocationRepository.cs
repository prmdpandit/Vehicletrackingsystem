using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.WebAPI.Data;
using VehicleTrackingSystem.WebAPI.Entities;
using VehicleTrackingSystem.WebAPI.Repository;

namespace VehicleTrackingSystem.WebAPI.Repository
{
    public class VehicleLocationRepository: Repository<VehicleLocation>, IVehicleLocationRepository
    {
        public VehicleLocationRepository(DatabaseContext context) : base(context) { }       

        public Task<VehicleLocation> GetVehicleLocationByDeviceId(Guid deviceId)
        {
            return context.Set<VehicleLocation>().
                FirstOrDefaultAsync(vehicleLocation => vehicleLocation.DeviceID == deviceId);
        }

       
    }
}
