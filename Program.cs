using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;

var builder = WebApplication.CreateBuilder(args);

var endpoint = builder.Configuration["CosmosDbSettings:Endpoint"]!;
var key = builder.Configuration["CosmosDbSettings:Key"]!;
var databaseName = builder.Configuration["CosmosDbSettings:DatabaseName"]!;

builder.Services.AddDbContext<MovieContext>(opts =>
    opts.UseCosmos(endpoint, key, databaseName));

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
