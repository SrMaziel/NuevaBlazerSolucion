using InformacionCrud.Cliente;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


using InformacionCrud.Cliente.Services;
using CurrieTechnologies.Razor.SweetAlert2;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5128") });

builder.Services.AddScoped<ITipodocumentoService, TipodocumentoService>();
builder.Services.AddScoped<ICiudadanoService, CiudadanoService>();


builder.Services.AddScoped<ITiposciudadanoService, TiposciudadanoService>();
builder.Services.AddScoped<ICiudadanoService, CiudadanoService>();

builder.Services.AddScoped<INacionalidadService, NacionalidadService>();
builder.Services.AddScoped<ICiudadanoService, CiudadanoService>();

builder.Services.AddScoped<iBienesService, BienesService>();
builder.Services.AddScoped<ICiudadanoService, CiudadanoService>();

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
