using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class TransactionDTO
{
    [Key]
    public int ProductId { get; set; }
    
    public int UserId { get; set; }

    public bool Type { get; set;} //si type = 1 -> compra || si type = 0 -> venta
    public DateTime Date { get; set;}



    // public List<VideogameGender> ListVideogameGender { get; set; }


     public Transaction ToTransaction()
    {
        return new Transaction
        {
            ProductId = this.ProductId,
            UserId = this.UserId,
            Type = this.Type,
            Date = this.Date
        };
    }
}