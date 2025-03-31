using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortfolioBackend.Controllers;
using PortfolioBackend.Models;
using PortfolioBackend.Service;
using Microsoft.AspNetCore.Http.Json;

namespace PortfolioBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : Controller
{
    private readonly ILogger<PostsController> _logger;
    private readonly IBlogService _blogService;

    public PostsController(ILogger<PostsController> logger, IBlogService blogService)
    {
        _logger = logger;
        _blogService = blogService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Post>>> GetAllPosts()
    {
        var posts = await _blogService.GetAllPosts();
        return Ok(posts);
    }
}
