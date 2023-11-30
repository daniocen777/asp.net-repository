using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Sales.WEB;
using Sales.WEB.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
// Colcando la url del backend
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7207/") });
// Colocar los repositorios para la inyeccion (3 formas de inyectar)
// => AddTrasient<>
// => AddSingleton<>
builder.Services.AddScoped<IRepository, Repository>(); // crear nueva instancia por inyeccion
// Alertas
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
