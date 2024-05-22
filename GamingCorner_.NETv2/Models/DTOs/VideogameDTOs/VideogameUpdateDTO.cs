using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace GamingCorner.Models;

public class VideogameUpdateDTO
{



    public string Name { get; set; }
    public int Stock { get; set; }

    public bool Available { get; set; }

    public decimal Price { get; set; }
}