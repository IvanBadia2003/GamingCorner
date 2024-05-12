using GamingCorner.Data;
using GamingCorner.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;


// var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy(name: MyAllowSpecificOrigins,
//                       policy  =>
//                       {
//                           policy.WithOrigins("http://tickett.retocsv.es:80")
//                             .AllowAnyMethod()
//                             .AllowAnyHeader();
//                       });
// });

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
// builder.Services.AddScoped<IObraRepository, ObraEFRepository>();

// builder.Services.AddScoped<ISeatService, SeatService>();
// builder.Services.AddScoped<ISeatRepository, SeatEFRepository>();

// builder.Services.AddScoped<IUserService, UserService>();
// builder.Services.AddScoped<IUserRepository, UserEFRepository>();

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

// app.UseCors(MyAllowSpecificOrigins);


app.UseAuthorization();
app.MapControllers();
app.Run();
