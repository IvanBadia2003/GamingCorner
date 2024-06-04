namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class SecondHandEFRepository : ISecondHandRepository
{


    private readonly GamingCornerContext _context;

    public SecondHandEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<SecondHandDTO> GetAll()
    {
        var secondHands = _context.SecondHands
            .ToList();

        if (secondHands != null)
        {
            var secondHandDto = secondHands.Select(g => new SecondHandDTO
            {
                SecondHandId = g.SecondHandId,
                Title = g.Title,
                Description = g.Description,
                Price = g.Price,

            }).ToList();
            return secondHandDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(SecondHand secondHand)
    {
        _context.SecondHands.Add(secondHand);
        SaveChanges();
    }

    public SecondHandDTO Get(int idSecondHand)
    {
        var secondHand = _context.SecondHands
            .Where(vg => vg.SecondHandId == idSecondHand)
            .FirstOrDefault();

        if (secondHand != null)
        {
            var videogameGenderDto = new SecondHandDTO
            {
                SecondHandId = secondHand.SecondHandId,
                Title = secondHand.Title,
                Description = secondHand.Description,
                Price = secondHand.Price,
            };
            return videogameGenderDto;
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

    public void Delete(int idSecondHand)
    {
        var secondHandDto = Get(idSecondHand);
        if (secondHandDto == null)
        {
            throw new KeyNotFoundException("Second Hand product not found.");
        }
        var secondHand = _context.SecondHands.FirstOrDefault(g => g.SecondHandId == idSecondHand) ;
        if (secondHand != null)
        {
            _context.SecondHands.Remove(secondHand);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
