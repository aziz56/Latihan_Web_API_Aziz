using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MyRestServices.BLL;
using MyRestServices.BLL.DTOs.Validation;
using MyRestServices.BLL.Interfaces;
using MyRestServices.Data;
using MyRestServices.Data.Interface;
using MyRestServices.Domain.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddValidatorsFromAssemblyContaining<CategoryCreateDTOValidator>();

//DI
builder.Services.AddScoped<ICategoryData, CategoryData>();
builder.Services.AddScoped<ICategoryBLL, CategoryBLL>();
builder.Services.AddScoped<IArticleBLL, ArticleBLL>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnectionString"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
