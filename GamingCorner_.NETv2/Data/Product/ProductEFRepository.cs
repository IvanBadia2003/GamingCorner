namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class ProductEFRepository : IProductRepository
{


    private readonly GamingCornerContext _context;

    public ProductEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<ProductDTO> GetAll()
    {
        var products = _context.Products
            .ToList();

        if (products != null)
        {
            var productDto = products.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                VideogameId = p.VideogameId,
                ConsoleId = p.ConsoleId,
            }).ToList();
            return productDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
        SaveChanges();
    }

    public ProductDTO Get(int id)
    {
        var product = _context.Products
            .FirstOrDefault();

        if (product != null)
        {
            var productDto = new ProductDTO
            {
                ProductId = product.ProductId,
                VideogameId = product.VideogameId,
                ConsoleId = product.ConsoleId,
                // CharacterImg = gender.CharacterImg,
                // ListVideogameGender = gender.ListVideogameGender
                //     .Where(bo => bo != null && bo.Videogame != null)
                //     .Select(bo => new VideogameGenderDTO
                //     {
                //         VideogameId = bo.VideogameId
                //     }).ToList()
            };
            return productDto;
        }
        else
        {
            return null;
        }
    }

    // public void Update(Gender gender)
    // {
    //     var existingGender = _context.Genders.Find(gender.GenderId);

    //     if (existingGender != null)
    //     {
    //         _context.Entry(existingGender).CurrentValues.SetValues(gender);
    //         _context.SaveChanges();
    //     }
    // }

    public void Delete(int id)
    {
        var productDto = Get(id);
        if (productDto == null)
        {
            throw new KeyNotFoundException("Product not found.");
        }
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
        if (product != null)
        {
            _context.Products.Remove(product);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
