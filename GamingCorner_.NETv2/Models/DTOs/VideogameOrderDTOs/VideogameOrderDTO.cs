using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class VideogameOrderDTO
{
    public int OrderId { get; set; }
    
    public int VideogameId { get; set; }


    // public List<VideogameGender> ListVideogameGender { get; set; }


     public VideogameOrder ToVideogameOrder()
    {
        return new VideogameOrder
        {
            OrderId = this.OrderId,
            VideogameId = this.VideogameId
        };
    }
}