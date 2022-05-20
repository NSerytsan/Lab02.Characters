using Lab02.Characters.Client;
using Lab02.Characters.Client.Services;
using Lab02.Characters.Client.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7262/") });
builder.Services.AddScoped<IWeaponTypeService, WeaponTypeService>();
builder.Services.AddScoped<IWeaponService, WeaponService>();

await builder.Build().RunAsync();
