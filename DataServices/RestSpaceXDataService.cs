using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApiClient.Dtos;

namespace BlazorApiClient.DataServices
{
    public class RestSpaceXDataService : ISpaceXDataService
    {
        
        private HttpClient _httpClient;
        
        public RestSpaceXDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<LaunchDto[]> GetAllLaunches()
        {
            return await _httpClient.GetFromJsonAsync<LaunchDto[]>("/rest/launches");
        }
    }
}