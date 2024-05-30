using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class OrderLineCreateDTO
{

    public int VideogameId { get; set; }
    public int ConsoleId { get; set; }
    public int OrderId { get; set; }
    public decimal SubtotalPrice { get; set; }
    public int Quantity { get; set; }



    // public List<Order> Orders { get; set; } = new List<Order>();

}