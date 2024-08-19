using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Transaction
{
    [ForeignKey("User")]
    public int UserId { get; set; }


    [ForeignKey("Product")]
    public int ProductId { get; set; }

    public User User { get; set; }
    public Product Product { get; set; }
    public bool Type { get; set;} //si type = 1 -> compra || si type = 0 -> venta

    public DateTime Date { get; set;} = DateTime.Now;


    public Transaction() { }

    public Transaction(int productId, int userId)
    {
        UserId = userId;
        ProductId = productId;
    }

    public Transaction mapFromCreateDto(TransactionCreateDTO transactionCreateDTO)
    {
        if (transactionCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(transactionCreateDTO));
        }

        var transaction = new Transaction
        {
            ProductId = transactionCreateDTO.ProductId,
            UserId = transactionCreateDTO.UserId,
        };

        return transaction;
    }
}