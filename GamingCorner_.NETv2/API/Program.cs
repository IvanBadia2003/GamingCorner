using GamingCorner.Data;
using GamingCorner.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using GamingCorner.Models;







var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";



var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrel(options =>
{
    options.ListenAnyIP(5000); // Puerto que desees, por ejemplo, 8000
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://tickett.retocsv.es:80")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                      });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
// }

// app.UseHttpsRedirection();
// var connectionString = builder.Configuration.GetConnectionString("ServerDB");
var connectionString = builder.Configuration.GetConnectionString("ServerDB");

// builder.Services.AddScoped<IObraService, ObraService>();
// builder.Services.AddScoped<IObraService, ObraService>();
// builder.Services.AddScoped<IObraRepository, ObraEFRepository>();

builder.Services.AddScoped<IVideogameService, VideogameService>();
builder.Services.AddScoped<IVideogameRepository, VideogameEFRepository>();

builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IGenderRepository, GenderEFRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserEFRepository>();

builder.Services.AddScoped<IVideogameGenderService, VideogameGenderService>();
builder.Services.AddScoped<IVideogameGenderRepository, VideogameGenderEFRepository>();

builder.Services.AddScoped<IPlatformService, PlatformService>();
builder.Services.AddScoped<IPlatformRepository, PlatformEFRepository>();

builder.Services.AddScoped<IConsoleService, ConsoleService>();
builder.Services.AddScoped<IConsoleRepository, ConsoleEFRepository>();

builder.Services.AddScoped<IOrderLineService, OrderLineService>();
builder.Services.AddScoped<IOrderLineRepository, OrderLineEFRepository>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderEFRepository>();

// builder.Services.AddScoped<IIngredienteService, IngredienteService>();
// builder.Services.AddScoped<IIngredientesRepository, IngredienteEFRepository>();

// builder.Services.AddDbContext<ObraContext>(options =>
//     options.UseSqlServer(connectionString)
//     .LogTo(Console.WriteLine, LogLevel.Information));
builder.Services.AddDbContext<GamingCornerContext>(Options =>
        Options.UseSqlServer(connectionString)
        .LogTo(Console.WriteLine,LogLevel.Information));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseCors(MyAllowSpecificOrigins);


app.UseAuthorization();
app.MapControllers();
app.Run();
