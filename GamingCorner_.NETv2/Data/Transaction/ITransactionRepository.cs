using GamingCorner.Models;

namespace GamingCorner.Data;

public interface ITransactionRepository
{
    List<TransactionDTO> GetAll();
    // GetAll(int id);
    void Add(Transaction transaction);
    TransactionDTO Get(int idProduct, int idUser);
    // void Update(Gender gender);
    void Delete(int idProduct, int idUser);
}