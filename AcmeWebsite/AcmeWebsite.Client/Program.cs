using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using static AcmeWebsite.Client.Pages.Home;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
