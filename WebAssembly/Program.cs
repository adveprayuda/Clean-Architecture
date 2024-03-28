using Application.Services;
using Blazored.Toast;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAssembly;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredToast();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7157/") });
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
//builder.Services.AddScoped<IToastService>();
await builder.Build().RunAsync();
