using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class ProductCreateDTO
{


     public int VideogameId { get; set; }
     public int ConsoleId { get; set; }
     public DateTime CreationDate { get; set; } = DateTime.Now;

}