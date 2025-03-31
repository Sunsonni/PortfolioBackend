using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioBackend.DTOs;
using PortfolioBackend.Models;

namespace PortfolioBackend.Service;

public interface IBlogService
{
    Task<Post> CreatePost(CreatePostRequest request);
    Task<List<Post>> GetAllPosts();
}
