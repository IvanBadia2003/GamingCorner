namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class VideogameService : IVideogameService
{

    private readonly IVideogameRepository _videogameRepository;


    public VideogameService(IVideogameRepository videgameRepository)
    {
        _videogameRepository = videgameRepository;

    }
    public List<VideogameDTO> GetAll()
    {
        var videogames = _videogameRepository.GetAll();
        return videogames;
    }

    public VideogameDTO Get(int id)
    {
        var videogame = _videogameRepository.Get(id);
        return videogame;
    }


    public void Add(VideogameCreateDTO videogameCreateDTO)
    {
        var videogame = new Videogame();
        var mappedVideogame = videogame.mapFromCreateDto(videogameCreateDTO);
        _videogameRepository.Add(mappedVideogame);
    }

    public void Update(int id, VideogameUpdateDTO videogameUpdateDTO)
    {
        var videogameDto = _videogameRepository.Get(id);
        if(videogameDto == null)
        {
            throw new KeyNotFoundException($"Videogame con Id {id} no encontrada.");
        }

        var videogame = videogameDto.ToVideogame();
        videogame.Stock = videogameDto.Stock;
        videogame.Available = videogameDto.Available;
        videogame.Price = videogameDto.Price;
        _videogameRepository.Update(videogame);
    }

    public void Delete(int id)
    {
        _videogameRepository.Delete(id);
    }
}


    
    

