using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SeeYa.Core;
using SeeYa.Core.Services;
using SeeYa.Core.Services.Repos;
using SeeYa.WebStudio;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
   .AddScoped<IStoryRepo, TestStoryRepo>()
   .AddScoped<IStoryNodeDataService, StoryNodeDataService>()
   .AddScoped<IStoryNodeRepo, TestStoryNodeRepo>()
   .AddScoped<IStoryDataService, StoryDataService>()
   .AddScoped<IStoryRunner, StoryRunner>()
   .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
