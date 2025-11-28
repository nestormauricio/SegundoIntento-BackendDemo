using BackendDemo.Repositories;
using BackendDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios a la inyección de dependencias
builder.Services.AddControllers();

// --- Repositorios individuales ---
builder.Services.AddSingleton<ProductRepository>();   // memoria
builder.Services.AddSingleton<SqliteProductRepository>();
builder.Services.AddSingleton<MongoProductRepository>();

// --- Repositorio compuesto ---
builder.Services.AddScoped<IProductRepository>(sp =>
{
    var mem = sp.GetRequiredService<ProductRepository>();
    var sqlite = sp.GetRequiredService<SqliteProductRepository>();
    var mongo = sp.GetRequiredService<MongoProductRepository>();
    return new CompositeProductRepository(mem, sqlite, mongo);
});

// --- Servicios ---
builder.Services.AddScoped<ProductService>();

// --- Swagger/OpenAPI ---
builder.Services.AddOpenApi();

var app = builder.Build();

// --- Middleware ---
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();




















// using BackendDemo.Repositories;
// using BackendDemo.Services;

// var builder = WebApplication.CreateBuilder(args);

// // Agregar servicios individuales
// builder.Services.AddSingleton<ProductRepository>();         // Memoria
// builder.Services.AddSingleton<MongoProductRepository>();    // MongoDB
// builder.Services.AddSingleton<SqliteProductRepository>();   // SQLite

// // Composite repository que combina los tres
// builder.Services.AddSingleton<IProductRepository>(sp =>
//     new CompositeProductRepository(
//         sp.GetRequiredService<ProductRepository>(),
//         sp.GetRequiredService<MongoProductRepository>(),
//         sp.GetRequiredService<SqliteProductRepository>()
//     )
// );

// builder.Services.AddScoped<ProductService>();
// builder.Services.AddControllers();
// builder.Services.AddOpenApi();

// var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

// app.UseHttpsRedirection();
// app.MapControllers();
// app.Run();























// using BackendDemo.Repositories;
// using BackendDemo.Services;

// var builder = WebApplication.CreateBuilder(args);

// // Agregar servicios a la inyección de dependencias
// builder.Services.AddControllers(); // <--- necesario para los controllers
// builder.Services.AddSingleton<IProductRepository, ProductRepository>();
// builder.Services.AddScoped<ProductService>();

// // Swagger/OpenAPI (opcional)
// builder.Services.AddOpenApi();

// var app = builder.Build();

// // Configuración de pipeline HTTP
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

// app.UseHttpsRedirection();

// // Mapear controllers
// app.MapControllers();

// app.Run();























// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

// builder.Services.AddSingleton<IProductRepository, ProductRepository>();
// builder.Services.AddScoped<ProductService>();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

// app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
