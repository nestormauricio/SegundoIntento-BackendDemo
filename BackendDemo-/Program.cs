using BackendDemo.Repositories;
using BackendDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// --- Controllers ---
builder.Services.AddControllers();

// --- Repositorios individuales (instancias concretas) ---
builder.Services.AddSingleton<ProductRepository>();      // Memoria
builder.Services.AddSingleton<SqliteProductRepository>(); // SQLite
builder.Services.AddSingleton<MongoProductRepository>();  // MongoDB

// --- Repositorio compuesto que implementa IProductRepository ---
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

// --- Pipeline ---
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

// // Agregar servicios a la inyección de dependencias
// <<<<<<< HEAD
// builder.Services.AddControllers(); // necesario para los controllers

// // --- Repositorios individuales (tipos concretos) ---
// =======
// builder.Services.AddControllers();

// // --- Repositorios individuales ---
// >>>>>>> stable
// builder.Services.AddSingleton<ProductRepository>();   // memoria
// builder.Services.AddSingleton<SqliteProductRepository>();
// builder.Services.AddSingleton<MongoProductRepository>();

// <<<<<<< HEAD
// // --- Repositorio compuesto (implementa IProductRepository) ---
// =======
// // --- Repositorio compuesto ---
// >>>>>>> stable
// builder.Services.AddScoped<IProductRepository>(sp =>
// {
//     var mem = sp.GetRequiredService<ProductRepository>();
//     var sqlite = sp.GetRequiredService<SqliteProductRepository>();
//     var mongo = sp.GetRequiredService<MongoProductRepository>();
//     return new CompositeProductRepository(mem, sqlite, mongo);
// });

// // --- Servicios ---
// builder.Services.AddScoped<ProductService>();

// // --- Swagger/OpenAPI ---
// builder.Services.AddOpenApi();

// var app = builder.Build();

// // --- Middleware ---
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
// builder.Services.AddControllers(); // necesario para los controllers

// // Repositorios individuales
// builder.Services.AddSingleton<IProductRepository, ProductRepository>(); // memoria
// builder.Services.AddSingleton<SqliteProductRepository>();
// builder.Services.AddSingleton<MongoProductRepository>();

// // Repositorio compuesto que usa los tres anteriores
// builder.Services.AddScoped<IProductRepository>(sp =>
// {
//     var mem = sp.GetRequiredService<ProductRepository>();
//     var sqlite = sp.GetRequiredService<SqliteProductRepository>();
//     var mongo = sp.GetRequiredService<MongoProductRepository>();
//     return new CompositeProductRepository(mem, sqlite, mongo);
// });

// // Servicio
// builder.Services.AddScoped<ProductService>();

// // Swagger/OpenAPI
// builder.Services.AddOpenApi();

// var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

// app.UseHttpsRedirection();
// app.MapControllers();
// app.Run();























// using BackendDemo.Domain;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace BackendDemo.Repositories;

// public class CompositeProductRepository : IProductRepository
// {
//     private readonly IProductRepository _memoryRepo;
//     private readonly IProductRepository _mongoRepo;
//     private readonly IProductRepository _sqliteRepo;

//     public CompositeProductRepository(
//         IProductRepository memoryRepo,
//         IProductRepository mongoRepo,
//         IProductRepository sqliteRepo)
//     {
//         _memoryRepo = memoryRepo;
//         _mongoRepo = mongoRepo;
//         _sqliteRepo = sqliteRepo;
//     }

//     public async Task<List<Product>> GetAll()
//     {
//         // Para GetAll devolvemos los productos del repo en memoria
//         return await _memoryRepo.GetAll();
//     }

//     public async Task<Product?> GetById(int id)
//     {
//         return await _memoryRepo.GetById(id);
//     }

//     public async Task<Product> Create(Product product)
//     {
//         var p1 = await _memoryRepo.Create(product);
//         var p2 = await _mongoRepo.Create(product);
//         var p3 = await _sqliteRepo.Create(product);
//         return p1; // devolver el de memoria
//     }

//     public async Task<Product?> Update(Product product)
//     {
//         var u1 = await _memoryRepo.Update(product);
//         var u2 = await _mongoRepo.Update(product);
//         var u3 = await _sqliteRepo.Update(product);
//         return u1;
//     }

//     public async Task<bool> Delete(int id)
//     {
//         var d1 = await _memoryRepo.Delete(id);
//         var d2 = await _mongoRepo.Delete(id);
//         var d3 = await _sqliteRepo.Delete(id);
//         return d1;
//     }
// }






















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
