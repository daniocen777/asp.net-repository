using WebApiExample.Services;
using WebApiExample.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// ****** Mapear los servicios creados con sus interfaces (Para inyectarlo)
builder.Services.AddSingleton<IUserDataService, UserDataService>(); // patron singleton
// builder.Services.AddScoped<IUserDataService, UserDataService>(); => crea la instancia por request
// builder.Services.AddTransient<IUserDataService, UserDataService>(); => crea la instancia por inyeccion// Middlewares

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// ***** Politicas
builder.Services.AddCors(p =>
{
    p.AddPolicy("MyCorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
                .WithOrigins("http://localhost:4200")
                .WithMethods("GET", "POST", "PUT", "DELETE")
                .Build();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ****** Middlewares personalizados
// De ejemplo
app.UseStatusMiddleware();
// Habilitar CORS (Mejor crear una politica)
//app.UseCors(builder =>
//{
//    builder.AllowAnyHeader()
//    .WithOrigins("http://localhost:4200")
//    .WithMethods("GET", "POST", "PUT", "DELETE")
//    .Build();
//});
app.UseCors("MyCorsPolicy"); // Tambien se puede usar Cors en los controladores con decorador [EnableCors("MyCorsPolicy")]

app.UseAuthorization();

app.MapControllers();



app.Run();
