using Supabase;
using Microsoft.Extensions.Configuration;
using PortfolioBackend.DTOs;
using PortfolioBackend.Models;
using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<BlogService>(_ => new BlogService(
    new Client (
        builder.Configuration["SUPABASE_URL"],
        builder.Configuration["SUPABASE_KEY"]
    )
));

builder.Services.Configure<JsonOptions>(options => 
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
})

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();

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
