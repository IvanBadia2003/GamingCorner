using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IPlatformRepository
{
    List<PlatformDTO> GetAll();
    // GetAll(int id);
    void Add(Platform platform );
    PlatformDTO Get(int id);
    // void Update(Gender gender);
    void Delete(int id);
}