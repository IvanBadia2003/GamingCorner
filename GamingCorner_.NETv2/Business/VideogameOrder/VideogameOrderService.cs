namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class VideogameOrderService : IVideogameOrderService
{

    private readonly IVideogameOrderRepository _videogameOrderRepository;


    public VideogameOrderService(IVideogameOrderRepository videogameOrderRepository)
    {
        _videogameOrderRepository = videogameOrderRepository;

    }
    public List<VideogameOrderDTO> GetAll()
    {
        var videogameOrders = _videogameOrderRepository.GetAll();
        return videogameOrders;
    }

    public VideogameOrderDTO Get(int idOrder, int idVideogame)
    {
        var videogameOrder = _videogameOrderRepository.Get(idOrder, idVideogame);
        return videogameOrder;
    }


    public void Add(VideogameOrderCreateDTO videogameOrderCreateDTO)
    {
        var videogameOrder = new VideogameOrder();
        var mappedVideogameOrder = videogameOrder.mapFromCreateDto(videogameOrderCreateDTO);
        _videogameOrderRepository.Add(mappedVideogameOrder);
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

    public void Delete(int idOrder, int idVideogame)
    {
        _videogameOrderRepository.Delete(idOrder, idVideogame);
    }
}


    
    

