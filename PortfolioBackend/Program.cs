using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Configuration;
using PortfolioBackend.DTOs;
using PortfolioBackend.Models;
using PortfolioBackend.Service;
using Supabase;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<Supabase.Client>(_ => new Client(
    builder.Configuration["SUPABASE_KEY"],
    builder.Configuration["SUPABASE_URL"],
    new SupabaseOptions { AutoRefreshToken = true }
));

builder.Services.AddScoped<IBlogService, BlogService>();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
