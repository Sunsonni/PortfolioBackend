using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supabase;
using PortfolioBackend.Models;
using PortfolioBackend.DTOs;

namespace PortfolioBackend.Supabase;

public class BlogService(Supabase.Client supabase)
{
    public async Task<Post> CreatePost(CreatePostRequest request)
    {
        var post = new Post { Title = request.Title };
        var response = await supabase.From<Post>().Insert(post);

        if (response.Models.Count == 0)
        {
            throw new Exception("Failed to create post");
        }

        return response.Models[0];
    }

    /*
     var posts = await _blogservice.GetAllPosts()
        return Okay(Posts);*/
    public async Task<List<Post>> GetAllPosts()
}
