using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Platform
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
    public int PlatformId { get; set; }

    public string? Name { get; set; }

    public Platform() { }

    public Platform(string name)
    {
        Name = name;
    }
}