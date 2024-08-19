namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class TransactionEFRepository : ITransactionRepository
{


    private readonly GamingCornerContext _context;

    public TransactionEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<TransactionDTO> GetAll()
    {
        var transactions = _context.Transactions
            .ToList();

        if (transactions != null)
        {
            var transactionDto = transactions.Select(g => new TransactionDTO
            {
                ProductId = g.ProductId,
                UserId = g.UserId,
            }).ToList();
            return transactionDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        SaveChanges();
    }

    public TransactionDTO Get(int idProduct, int idUser)
    {
        var transaction = _context.Transactions
            .Where(t => t.ProductId == idProduct && t.UserId == idUser)
            .FirstOrDefault();

        if (transaction != null)
        {
            var transactionDto = new TransactionDTO
            {
                ProductId = transaction.ProductId,
                UserId = transaction.UserId
            };
            return transactionDto;
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

    public void Delete(int idProduct, int idUser)
    {
        var transactionDto = Get(idProduct, idUser);
        if (transactionDto == null)
        {
            throw new KeyNotFoundException("Transaction not found.");
        }
        var transaction = _context.Transactions.FirstOrDefault(t => t.ProductId == idProduct && t.UserId == idUser) ;
        if (transaction != null)
        {
            _context.Transactions.Remove(transaction);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
