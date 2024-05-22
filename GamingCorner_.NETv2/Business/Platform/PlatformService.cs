namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class PlatformService : IPlatformService
{

    private readonly IPlatformRepository _platformRepository;


    public PlatformService(IPlatformRepository platformRepository)
    {
        _platformRepository = platformRepository;

    }
    public List<PlatformDTO> GetAll()
    {
        var platforms = _platformRepository.GetAll();
        return platforms;
    }

    public PlatformDTO Get(int id)
    {
        var platform = _platformRepository.Get(id);
        return platform;
    }


    public void Add(PlatformCreateDTO platformCreateDTO)
    {
        var platform = new Platform();
        var mappedPlatform = platform.mapFromCreateDto(platformCreateDTO);
        _platformRepository.Add(mappedPlatform);
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

    public void Delete(int id)
    {
        _platformRepository.Delete(id);
    }
}


    
    

