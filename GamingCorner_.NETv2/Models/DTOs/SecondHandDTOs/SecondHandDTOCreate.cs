using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class SecondHandCreateDTO
{


    public int SecondHandId { get; set; }
    
    public string? Title { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }
}