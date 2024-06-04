namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class ConsoleOrderService : IConsoleOrderService
{

    private readonly IConsoleOrderRepository _consoleOrderRepository;


    public ConsoleOrderService(IConsoleOrderRepository consoleOrderRepository)
    {
        _consoleOrderRepository = consoleOrderRepository;

    }
    public List<ConsoleOrderDTO> GetAll()
    {
        var videogameOrders = _consoleOrderRepository.GetAll();
        return videogameOrders;
    }

    public ConsoleOrderDTO Get(int idConsole, int idOrder)
    {
        var consoleOrder = _consoleOrderRepository.Get(idConsole, idOrder);
        return consoleOrder;
    }


    public void Add(ConsoleOrderCreateDTO consoleOrderCreateDTO)
    {
        var consoleOrder = new ConsoleOrder();
        var mappedConsoleOrder = consoleOrder.mapFromCreateDto(consoleOrderCreateDTO);
        _consoleOrderRepository.Add(mappedConsoleOrder);
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

    public void Delete(int idConsole, int idOrder)
    {
        _consoleOrderRepository.Delete(idConsole, idOrder);
    }
}


    
    

