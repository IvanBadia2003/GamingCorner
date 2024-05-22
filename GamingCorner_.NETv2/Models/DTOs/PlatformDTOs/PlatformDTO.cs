using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class PlatformDTO
{
    [Key]
    public int PlatformId { get; set; }

    public string? Name { get; set; }

    public List<Videogame> videogames {get; set;} = new List<Videogame>();
    public List<Console_> consoles {get; set;} = new List<Console_>();

     public Platform ToPlatform()
    {
        return new Platform
        {
            PlatformId = this.PlatformId,
            Name = this.Name,
        };
    }
}