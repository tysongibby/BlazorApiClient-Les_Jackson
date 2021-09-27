using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApiClient.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorApiClient.Pages
{
    public partial class FetchData
    {
        [Inject]
        private HttpClient Http {get; set; }
       
        private LaunchDto[] Launches;

        protected override async Task OnInitializedAsync()
        {
            Launches = await Http.GetFromJsonAsync<LaunchDto[]>("/rest/launches");
        }

    }
}