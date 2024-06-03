using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class OrderDTO
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime Date { get; set; }
    public string? Address { get; set; }
    public string? BillingAddress { get; set; }
    public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

     public Order ToOrder()
    {
        return new Order
        {
            OrderId = this.OrderId,
            UserId = this.UserId,
            TotalPrice = this.TotalPrice,
            Date = this.Date,
            Address = this.Address,
            BillingAddress = this.BillingAddress,
        }; 
    }
}