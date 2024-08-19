using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class ProductDTO
{
    [Key]
    public int ProductId { get; set; }
    public int VideogameId { get; set; }
    public int ConsoleId { get; set; }
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();


     public Product ToProduct()
    {
        return new Product
        {
            ProductId = this.ProductId,
            VideogameId = this.VideogameId,
            ConsoleId = this.ConsoleId,
            Transactions = this.Transactions != null ? this.Transactions.Select(g => new Transaction
            {
                User = new User {UserId = g.UserId}
            }).ToList() : null
        };
    }
}