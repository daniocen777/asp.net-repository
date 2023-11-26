using WebApiExample.Services;
using WebApiExample.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Mapear los servicios creados con sus interfaces (Para inyectarlo)
builder.Services.AddSingleton<IUserDataService, UserDataService>(); // patron singleton
// builder.Services.AddScoped<IUserDataService, UserDataService>(); => crea la instancia por request
// builder.Services.AddTransient<IUserDataService, UserDataService>(); => crea la instancia por inyeccion// Middlewares

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

// Middlewares personalizados
app.UseStatusMiddleware();

app.Run();
