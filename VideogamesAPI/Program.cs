using Microsoft.EntityFrameworkCore;
using VideogamesAPI.Data;
using VideogamesAPI.Model.Repositories;
using VideogamesAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IDeveloperRepository, DeveloperService>();

var app = builder.Build();

app.MapControllers();

app.Run();