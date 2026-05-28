
using BeautySalonExpolorer.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDataAccessLayer(builder.Configuration);

builder.Services.AddBusinessLogicLayer();

builder.Services.AddCors();

builder.Services.AddOpenApi();

var app = builder.Build();

await app.Services.InitializeDatabaseAsync();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173"));

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
