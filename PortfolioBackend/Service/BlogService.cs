using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supabase;
using PortfolioBackend.Models;
using PortfolioBackend.DTOs;

namespace PortfolioBackend.Service;

public class BlogService : IBlogService 
{
    private readonly Client _supabase;

    //Constructor
    public BlogService(Client supabase)
    {
        _supabase = supabase;
    }

    //Method: Get all posts from supabase
    public async Task<List<Post>> GetAllPosts()
    {
        var response = await _supabase.From<Post>().Get();
        return response.Models;
    }

    //Method: Create new post
    public async Task<Post> CreatePost(CreatePostRequest request)
    {
        var post = new Post { Title = request.Title };
        var response = await _supabase.From<Post>().Insert(post);

        if (response.Models.Count == 0)
        {
            throw new Exception("Failed to create post");
        }

        return response.Models[0];
    }
}

