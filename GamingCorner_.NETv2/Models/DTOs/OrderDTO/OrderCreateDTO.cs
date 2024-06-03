using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class OrderCreateDTO
{

    public int OrderId { get; set; }
    public int UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime Date { get; set; }
    public string? Address { get; set; }
    public string? BillingAddress { get; set; }

}