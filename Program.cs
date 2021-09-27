using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorApiClient.DataServices;

namespace BlazorApiClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["api_base_url"]) });

            builder.Services.AddHttpClient<ISpaceXDataService, GraphQlSpaceXDataService>
                (spds => spds.BaseAddress = new Uri(builder.Configuration["api_base_url"]));
            // data service can be swapped for any data service implementing the ISpaceXDataService interface
            // builder.Services.AddHttpClient<ISpaceXDataService, RestSpaceXDataService>
            //     (spds => spds.BaseAddress = new Uri(builder.Configuration["api_base_url"]));


            await builder.Build().RunAsync();
        }
    }
}
