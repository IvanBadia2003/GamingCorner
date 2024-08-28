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


    public void Delete(int id)
    {
        _platformRepository.Delete(id);
    }
}


    
    

