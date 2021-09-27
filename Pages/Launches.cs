using System.Threading.Tasks;
using BlazorApiClient.DataServices;
using BlazorApiClient.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorApiClient.Pages
{
    public partial class Launches
    {

        [Inject]
        ISpaceXDataService SpaceXDataService {get; set; }

        private LaunchDto[] launches { get; set; }

        protected override async Task OnInitializedAsync()
        {
            launches = await SpaceXDataService.GetAllLaunches();
        }

    }
}