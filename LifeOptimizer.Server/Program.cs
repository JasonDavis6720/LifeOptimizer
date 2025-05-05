using Microsoft.EntityFrameworkCore;
using LifeOptimizer.Infrastructure.Data;
using LifeOptimizer.Application.Interfaces;
using LifeOptimizer.Core.Interfaces;
using LifeOptimizer.Server.Services;
using LifeOptimizer.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

builder.Services.AddScoped<IStorageElementService, StorageElementService>();
builder.Services.AddScoped<IStorageElementRepository, StorageElementRepository>();


// Add controllers and JSON options

builder.Services.AddControllers();
// Uncomment the following lines if you need to deal with circular references in JSON serialization

//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
//    });

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configure Authorization 
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(); // If needed, configure authentication schemes here.


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();
