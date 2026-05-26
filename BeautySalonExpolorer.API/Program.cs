using BeautySalonExpolorer.BLL.Interfaces;
using BeautySalonExpolorer.BLL.Services;
using BeautySalonExpolorer.DAL.Interfaces;
using BeautySalonExpolorer.DAL.Persistence;
using BeautySalonExpolorer.DAL.Persistence.Seed;
using BeautySalonExpolorer.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
});

builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddScoped<ISalonRepository, SalonRepository>();
builder.Services.AddScoped<ISalonService, SalonService>();



var app = builder.Build();


using (var scope = app.Services.CreateAsyncScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    await context.Database.MigrateAsync();
    await DbInitializer.SeedDataAsync(context, "enriched_salons.json");
}


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();
