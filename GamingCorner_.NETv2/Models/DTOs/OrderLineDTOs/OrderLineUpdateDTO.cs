using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace GamingCorner.Models;

public class OrderLineUpdateDTO
{
    public decimal SubtotalPrice { get; set; }
    public int Quantity { get; set; }

}