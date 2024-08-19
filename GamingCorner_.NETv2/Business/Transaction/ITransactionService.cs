namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface ITransactionService
{
    List<TransactionDTO> GetAll();
    // GetAll(int id);
    void Add(TransactionCreateDTO transactionCreateDTO);
    TransactionDTO Get(int idProduct, int idUser);
    void Delete(int idProduct, int idUser);
}
