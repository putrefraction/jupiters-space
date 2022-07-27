using System.ComponentModel.DataAnnotations; //[Required], [StringLength]
using System.ComponentModel.DataAnnotations.Schema; //[Column]
using Microsoft.EntityFrameworkCore;

namespace JupitersSpace.Shared;

public class Post 
{
    //These properties map to columns in the database
    [Required]
    public int PostId { get; set; }
    [Required]
    public string? Title { get; set; }
    public string? Subtitle { get; set; }
    public string? PostDate { get; set; }
    [Required]
    public string? Content { get; set; }
    public string? Slug { get; set; }

}