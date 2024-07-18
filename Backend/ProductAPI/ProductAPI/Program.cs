using BLL.Services;
using AutoMapper;
using BLL.Mapper; 
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register IRepository<Product, int, Product> with ProductRepository
builder.Services.AddScoped<IRepository<Product, int, Product>, ProductRepository>();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile)); // Assuming AutoMapper profiles are in the same assembly as Startup

// Register ProductService with IMapper dependency
builder.Services.AddScoped<ProductService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
