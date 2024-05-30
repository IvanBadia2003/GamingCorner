using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class OrderLineDTO
{
    public int OrderLineId { get; set; }
    public int VideogameId { get; set; }
    public int ConsoleId { get; set; }
    public int OrderId { get; set; }
    public decimal SubtotalPrice { get; set; }
    public int Quantity { get; set; }

     public OrderLine ToVideogame()
    {
        return new OrderLine
        {
            VideogameId = this.VideogameId,
            OrderLineId = this.OrderLineId,
            ConsoleId = this.ConsoleId,
            Quantity = this.Quantity,
            SubtotalPrice = this.SubtotalPrice,
        }; 
    }
}