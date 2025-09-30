using Application.IAppServices;
using Application.Mappings;
using AutoMapper.Extensions.ExpressionMapping;
using Domain.IRepositories;
using Infrastructure.Application.AppServices;
using Infrastructure.Domain.Repositories;
using Infrastructure.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddAutoMapper(configuration =>
{
    configuration.AddExpressionMapping();
    configuration.AddProfile<BudgetProfile>();
    configuration.AddProfile<ExpenseProfile>();
    AppDomain.CurrentDomain.GetAssemblies();
});

builder.Services.AddControllers();

// Add Swagger services  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in development  
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

//app.UseHttpsRedirection();  

app.UseAuthorization();

app.MapControllers();

app.Run();
