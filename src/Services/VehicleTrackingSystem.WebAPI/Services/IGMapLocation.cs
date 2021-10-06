using System.Threading.Tasks;
using VehicleTrackingSystem.WebAPI.Services.Model;

namespace VehicleTrackingSystem.WebAPI.Services
{
    public interface IGMapLocationService
    {
        Task<string> GetNearByLocation(Coord coord);
        
    }
}
