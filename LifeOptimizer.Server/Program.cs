using Microsoft.EntityFrameworkCore;
using LifeOptimizer.Infrastructure.Data;
using LifeOptimizer.Application.Interfaces;
using LifeOptimizer.Core.Interfaces;
using LifeOptimizer.Server.Services;
using LifeOptimizer.Infrastructure.Repositories;
using LifeOptimizer.Application.Mappings;
using AutoMapper;
using LifeOptimizer.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

builder.Services.AddScoped<IStorageElementService, StorageElementService>();
builder.Services.AddScoped<IStorageElementRepository, StorageElementRepository>();

builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

builder.Services.AddScoped<IUserContextService, StubUserContextService>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<StorageElementProfile>();
    cfg.AddProfile<ItemProfile>();
});

// Add controllers and JSON options

builder.Services.AddControllers();

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
