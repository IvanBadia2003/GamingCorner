namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class TransactionService : ITransactionService
{

    private readonly ITransactionRepository _transactionRepository;


    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;

    }
    public List<TransactionDTO> GetAll()
    {
        var transactions = _transactionRepository.GetAll();
        return transactions;
    }

    public TransactionDTO Get(int id)
    {
        var transaction = _transactionRepository.Get(id);
        return transaction;
    }


    public void Add(TransactionCreateDTO transactionCreateDTO)
    {
        var transaction = new Transaction();
        var mappedTransaction = transaction.mapFromCreateDto(transactionCreateDTO);
        _transactionRepository.Add(mappedTransaction);
    }


    public void Delete(int id)
    {
        _transactionRepository.Delete(id);
    }
}


    
    

