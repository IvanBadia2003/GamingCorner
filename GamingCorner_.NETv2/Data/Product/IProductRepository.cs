using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IProductRepository
{
    List<ProductDTO> GetAll();
    // GetAll(int id);
    void Add(Product product );
    ProductDTO Get(int id);
    // void Update(Gender gender);
    void Delete(int id);
}