using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supabase;
using PortfolioBackend.Models;
using PortfolioBackend.DTOs;

namespace PortfolioBackend.Supabase
{

    public class BlogService
    {
        private readonly Client _supabaseClient;

        public BlogService(Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }

        public async Task<Post> CreatePost(Post post)
        {
            var response = await _supabaseClient.From<Post>().Insert(post);

            if (response.Models.Count == 0)
            {
                throw new Exception("Failed to create post");
            }

            return response.Models[0];
        }
    }
}
