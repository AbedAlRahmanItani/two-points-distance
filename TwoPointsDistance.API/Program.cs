using FluentValidation;
using TwoPointsDistance.Application.Interfaces;
using TwoPointsDistance.Application.Models;
using TwoPointsDistance.Application.Services;
using TwoPointsDistance.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDistanceCalculationService, DistanceCalculationService>();
builder.Services.AddScoped<IValidator<DistanceCalculationRequest>, DistanceCalculationRequestValidator>();

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