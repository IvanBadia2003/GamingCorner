namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class SecondHandService : ISecondHandService
{

    private readonly ISecondHandRepository _secondHandRepository;


    public SecondHandService(ISecondHandRepository secondHandRepository)
    {
        _secondHandRepository = secondHandRepository;

    }
    public List<SecondHandDTO> GetAll()
    {
        var secondHands = _secondHandRepository.GetAll();
        return secondHands;
    }

    public SecondHandDTO Get(int idSecondHand)
    {
        var secondHand = _secondHandRepository.Get(idSecondHand);
        return secondHand;
    }


    public void Add(SecondHandCreateDTO secondHandCreateDTO)
    {
        var secondHand = new SecondHand();
        var mappedSecondHand = secondHand.mapFromCreateDto(secondHandCreateDTO);
        _secondHandRepository.Add(mappedSecondHand);
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

    public void Delete(int idSecondHand)
    {
        _secondHandRepository.Delete(idSecondHand);
    }
}


    
    

