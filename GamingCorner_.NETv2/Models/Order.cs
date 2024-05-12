using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }
    
    [ForeignKey("User")]
    public int UserId { get; set; }

    public User User{ get; set; }
    // [ForeignKey("Videogame")]
    // public int VideogameId { get; set; }
    // [ForeignKey("Console")]
    // public int ConsoleId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime Date { get; set; }
    public string? Address { get; set; }
    public string? BillingAddress { get; set; }

    public List<OrderLine> Order_Lines { get; set; } = new List<OrderLine>();


    public Order() { }

    public Order(decimal totalPrice, DateTime date, string address, string billingAddress)
    {
        TotalPrice = totalPrice;
        Date = date;
        Address = address;
        BillingAddress = billingAddress;
    }
}