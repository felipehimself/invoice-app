using InvoiceApp.Data;
using InvoiceApp.Interfaces;
using InvoiceApp.Models;
using InvoiceApp.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.MapType<DateTime>(() => new Microsoft.OpenApi.Models.OpenApiSchema { Type = "string", Format = "date"}));

// mysql connection
string connectionString = builder.Configuration.GetConnectionString("MySqlConnection")!;
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33")));

// scopes
builder.Services.AddScoped<IGenericRepository<Client>, ClientRepository>();
builder.Services.AddScoped<IGenericRepository<Invoice>, InvoiceRepository>();

// ignore object cycle for post methods
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// lowercase urls
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

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
