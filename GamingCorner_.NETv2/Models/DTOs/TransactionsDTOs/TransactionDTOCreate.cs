using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class TransactionCreateDTO
{


    public int ProductId { get; set; }
    public int UserId { get; set; }
    public bool Type { get; set;} //si type = 1 -> compra || si type = 0 -> venta

    public DateTime Date { get; set;} = DateTime.Now;

}