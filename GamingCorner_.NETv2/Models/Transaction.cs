using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Transaction
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public bool Type { get; set; }
    public Transaction(){}

    public Transaction(decimal amount, DateTime date, bool type){
        Amount = amount;
        Date = date;
        Type = type;
    }
}