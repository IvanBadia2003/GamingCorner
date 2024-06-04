using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class ConsoleOrderDTO
{
    [Key]
    public int ConsoleId { get; set; }
    
    public int OrderId { get; set; }


    // public List<VideogameGender> ListVideogameGender { get; set; }


     public ConsoleOrder ToConsoleOrder()
    {
        return new ConsoleOrder
        {
            OrderId = this.OrderId,
            ConsoleId = this.ConsoleId,
        };
    }
}