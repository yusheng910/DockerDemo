using demo_web_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RestaurantDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.UseDefaultFiles();

app.UseStaticFiles();

app.MapFallbackToFile("index.html");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/get-restaurant/{categoryId}", async (int categoryId, RestaurantDbContext db) =>
{
    int x = categoryId;

    List<RestaurantResponseModel> restaurants = await db.Restaurant
    .Where(r => r.CategoryId == categoryId)
    .Select(r => new RestaurantResponseModel { restaurnatName = r.RestaurantName })
    .ToListAsync();

    if (restaurants.Count == 0)
    {
        return Results.NotFound();
    }

    int index = RandomNumberGenerator.GetInt32(restaurants.Count);
    RestaurantResponseModel selectedRestaurant = restaurants[index];
    ApiResponse<RestaurantResponseModel> apiResponse = new ApiResponse<RestaurantResponseModel>
    {
        success = true,
        data = selectedRestaurant
    };

    return Results.Ok(apiResponse);

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
