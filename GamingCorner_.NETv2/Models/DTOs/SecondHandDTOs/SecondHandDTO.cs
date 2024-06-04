using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class SecondHandDTO
{

    public int SecondHandId { get; set; }
    
    public string? Title { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }




    // public List<VideogameGender> ListVideogameGender { get; set; }


     public SecondHand ToSecondHand()
    {
        return new SecondHand
        {
            Title = this.Title,
            Description = this.Description,
            Price = this.Price,
        };
    }
}