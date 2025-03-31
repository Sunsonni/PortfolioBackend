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

// app.MapPost("/post", async (CreateBlogPostRequest request, Supabase.Client client) => 
//     {
//         //creating post
//         var post = new Post
//         {
//             Title = request.Title
//         };

//         //inputing into table
//         var response = await client.From<Post>().Insert(post);

//         var sections = request.Sections.Select(s => new Section {
//             PostId = postResponse.Models[0].Id, // Use generated ID
//             Title = s.Title,
//             Content = s.Content
//          }).ToList();

//          await client.From<Section>().Insert(sections);

//         if (response.Models.Count == 0)
//         {
//             return Results.BadRequest("Failed to create post");
//         }

//         var createdPost = response.Models[0];

//         return Results.Created($"/post/{createdPost.Id}", createdPost);
//     }
// );

app.UseHttpsRedirection();

app.Run();
