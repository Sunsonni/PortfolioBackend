using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace PortfolioBackend.Models;

public class Sections : BaseModel
{
    [PrimaryKey("id", false)]
    public int Id { get; set; }

    [Column("post_id")]
    public int PostId { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("content")]
    public string? Content { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Reference(typeof(Post))]
    public Post Post { get; set; }
}

 