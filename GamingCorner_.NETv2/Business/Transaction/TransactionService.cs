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

    public TransactionDTO Get(int idProduct, int idUser)
    {
        var transaction = _transactionRepository.Get(idProduct, idUser);
        return transaction;
    }


    public void Add(TransactionCreateDTO transactionCreateDTO)
    {
        var transaction = new Transaction();
        var mappedTransaction = transaction.mapFromCreateDto(transactionCreateDTO);
        _transactionRepository.Add(mappedTransaction);
    }

    // public void Update(int id, VideogameUpdateDTO videogameUpdateDTO)
    // {
    //     var videogameDto = _genderRepository.Get(id);
    //     if(videogameDto == null)
    //     {
    //         throw new KeyNotFoundException($"Videogame con Id {id} no encontrada.");
    //     }

    //     var videogame = videogameDto.ToVideogame();
    //     videogame.Stock = videogameDto.Stock;
    //     videogame.Available = videogameDto.Available;
    //     videogame.Price = videogameDto.Price;
    //     _genderRepository.Update(videogame);
    // }

    public void Delete(int idProduct, int idUser)
    {
        _transactionRepository.Delete(idProduct, idUser);
    }
}


    
    

