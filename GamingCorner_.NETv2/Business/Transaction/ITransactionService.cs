namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface ITransactionService
{
    List<TransactionDTO> GetAll();
    // GetAll(int id);
    void Add(TransactionCreateDTO transactionCreateDTO);
    TransactionDTO Get(int id);
    void Delete(int id);
}
