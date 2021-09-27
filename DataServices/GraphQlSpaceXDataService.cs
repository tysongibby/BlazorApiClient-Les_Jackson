using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorApiClient.Dtos;

namespace BlazorApiClient.DataServices
{
    public class GraphQlSpaceXDataService : ISpaceXDataService
    {
        private readonly HttpClient _httpclient;

        public GraphQlSpaceXDataService(HttpClient httpClient)
        {
            _httpclient = httpClient;
        }
        public async Task<LaunchDto[]> GetAllLaunches()
        {
            // can use Strawberry Shake client library https://chillicream.com instead
            var queryObject = new
            {
                query = @"{launches{id is_tentative mission_name launch_date_local}}",
                variables = new { }
            };

            var launchQuery = new StringContent(
                JsonSerializer.Serialize(queryObject),
                Encoding.UTF8,
                "application/json");

            var response = await _httpclient.PostAsync("graphql", launchQuery);

            if(response.IsSuccessStatusCode)
            {
                var gqlData = await JsonSerializer.DeserializeAsync<GqlDataDto>(await response.Content.ReadAsStreamAsync());     
                return gqlData.Data.Launches;           
            }
            return null;
        }
    }
}