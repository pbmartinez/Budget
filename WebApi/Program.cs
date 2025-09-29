using Application.IAppServices;
using AutoMapper;
using Domain.IRepositories;
using Infrastructure.Application.AppServices;
using Infrastructure.Domain.Repositories;
using Infrastructure.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection; // Ensure this namespace is included for AutoMapper extensions

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IBudgetAppService, BudgetAppService>();
builder.Services.AddScoped<IExpenseAppService, ExpenseAppService>();

builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();

// Fix: Replace 'AddAutoMapperWithProfiles' with 'AddAutoMapper' and configure profiles if needed
builder.Services.AddAutoMapper(cfg => { cfg.AddMaps(typeof(Program)); });


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
