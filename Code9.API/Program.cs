using Code9.Domain.Handlers;
using Code9.Domain.Interfaces;
using Code9.Infrastructure;
using Code9.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CinemaDbContext>(options =>
    options.UseInMemoryDatabase("Cinemas"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//registration repository
builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetAllCinemaHandler).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    using var dbContext = scope.ServiceProvider.GetRequiredService<CinemaDbContext>();
    dbContext.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
