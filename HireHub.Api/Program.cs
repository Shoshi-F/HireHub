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
// using ProFit.Service.Validators; // �� ����� ����� ��� �����
using FluentValidation;
using Amazon.S3;
using Amazon.Extensions.NETCore.Setup;
using DotNetEnv; // ��� ������� ������
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;

// ������ ������� - ��� ������ settings.env ���� ����� �� �� ������� �������
Env.Load("settings.env");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
               .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler =
                        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

// ������ ������� - ��� ������� ����� �� ����� ������ CONNECTION_STRING
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
});

// ������ ������� - ��� ��� �������� ������� ������
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// ������ ������� - ��� ������ MappingProfile ����� ������� �����
builder.Services.AddAutoMapper(typeof(Program));

// ����� ������� �-container
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
        c.RoutePrefix = string.Empty; // ����� Swagger ��� ���� �� ������
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();