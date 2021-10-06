using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VehicleTrackingSystem.WebAPI.Services;
using VehicleTrackingSystem.WebAPI.Services.Model;

namespace VehicleTrackingSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ExternalController : ControllerBase
    {
        private readonly IGMapLocationService _gMapLocationService;

        public ExternalController( IGMapLocationService gMapLocationService)
        {
            _gMapLocationService = gMapLocationService;
        }

        [HttpGet]        
        
        public async Task<string> GetVehicleCurrentPosition(Coord coord)
        {
            var LocalityName = await _gMapLocationService.GetNearByLocation(coord);            
            
            return LocalityName;
        }

    }
}
