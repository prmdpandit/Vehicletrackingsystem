using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VehicleTrackingSystem.WebAPI.Services.Model;

namespace VehicleTrackingSystem.WebAPI.Services
{
    public class GMapLocationService : IGMapLocationService
    {
        string GoogleMap_API_KEY = "";
        private HttpClient _httpClient { get; set; }
        private IHttpClientFactory _clientFactory;
        public GMapLocationService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<string> GetNearByLocation(Coord coord)
        {
            
            string requestUri = string.Format("https://maps.googleapis.com/maps/api/place/nearbysearch/json?latlng={0}&key={1}", coord, GoogleMap_API_KEY);

            _httpClient = _clientFactory.CreateClient();
            HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            
            GMapResponseModel deserialized = JsonConvert.DeserializeObject<GMapResponseModel>(result);
            
            return deserialized.results.Select(x => new Address_Components
            {
                long_name = x.address_components.FirstOrDefault().long_name
            }).Where(x => x.types.ToString() == "sublocality").ToString();
        }
    }
}
