using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTrackingSystem.WebAPI.Entities;
using VehicleTrackingSystem.WebAPI.Repository;

namespace VehicleTrackingSystem.WebAPI.Controllers
{
    [Route("api/vehiclelocation")]
    [ApiController]
    public class VehicleLocationController : ControllerBase
    {
        private IVehicleLocationRepository _vehicleLocationRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<VehicleLocationController> _logger;


        public VehicleLocationController(IVehicleLocationRepository vehicleLocationRepository,
            ILogger<VehicleLocationController> logger,
            IMemoryCache memoryCache)
        {
            _vehicleLocationRepository = vehicleLocationRepository;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        [HttpGet("")]
        public IEnumerable<VehicleLocation> GetAllVehicleLocation() => _vehicleLocationRepository.GetAll();

        [HttpGet("{deviceId}")]
        public async Task<VehicleLocation> GetVehicleLocationByDevice(Guid deviceId)
        {
           if(_memoryCache.TryGetValue(deviceId, out VehicleLocation vehicleLocation))
            {
                vehicleLocation = await _vehicleLocationRepository.GetVehicleLocationByDeviceId(deviceId);
                var cacheExpirationOptions =
                    new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(1),
                        Priority = CacheItemPriority.Normal,
                        SlidingExpiration = TimeSpan.FromSeconds(30)
                    };
                _memoryCache.Set(deviceId, vehicleLocation, cacheExpirationOptions);
            }
           return vehicleLocation;
        }

        [HttpPost("")]
        [AllowAnonymous]
        public void AddVehicleLocation([FromBody] VehicleLocation vehicleLocation) => _vehicleLocationRepository.Insert(vehicleLocation);
    }
}
