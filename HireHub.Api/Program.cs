using HireHub.Data;
using Microsoft.EntityFrameworkCore;
using HireHub.Service.Services;
using HireHub.Core.IServices;
using HireHub.Core.IRepositories;
using HireHub.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
// using ProFit.Service.Validators; // לא עשיתי עדיין כזו תקייה
using FluentValidation;
using Amazon.S3;
using Amazon.Extensions.NETCore.Setup;
using DotNetEnv; // ודא שהחבילה מותקנת
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;

// טעויות אפשריות - ודא שהקובץ settings.env קיים וכולל את כל ההגדרות הנדרשות
Env.Load("settings.env");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
               .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler =
                        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

// טעויות אפשריות - ודא שהסביבה מכילה את משתנה הסביבה CONNECTION_STRING
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
});

// טעויות אפשריות - ודא שכל השירותים הנדרשים רשומים
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// טעויות אפשריות - ודא שמחלקת MappingProfile קיימת ומוגדרת כראוי
builder.Services.AddAutoMapper(typeof(Program));

// הוספת שירותים ל-container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // הפיכת Swagger לדף הבית של היישום
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();