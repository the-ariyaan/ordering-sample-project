using Api;
using AutoMapper;
using Domain.Contracts.Repository;
using Infrastructure.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add DbContext
services.AddDbContext<OrderingDbContext>();

// Add repositories and services to the container.
services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(Program).Assembly);


// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure AutoMapper
var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
builder.Services.AddSingleton(config.CreateMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<OrderingDbContext>();
    dataContext.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();