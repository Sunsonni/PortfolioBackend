using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioBackend.DTOs;

public class CreateSectionRequest
{
    public string? Type { get; set; }
    public string? Content { get; set; }
}
