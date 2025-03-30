using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioBackend.DTOs;

public class CreateBlogPostRequest
{
    public string Title { get; set; } = string.Empty;

    public List<CreateSectionRequest> Sections { get; set; } = new();
}
