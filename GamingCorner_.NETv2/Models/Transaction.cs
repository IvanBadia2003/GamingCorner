using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Transaction
{
    [Key]
    public int TransactionId { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    [ForeignKey("Videogame")]
    public int VideogameId { get; set; }
    [ForeignKey("Console")]
    public int ConsoleId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public bool Type { get; set; }
    public Transaction() { }

    public Transaction(decimal amount, DateTime date, bool type)
    {
        Amount = amount;
        Date = date;
        Type = type;
    }
}