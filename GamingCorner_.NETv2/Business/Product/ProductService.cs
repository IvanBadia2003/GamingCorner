namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class ProductService : IProductService
{

    private readonly IProductRepository _productRepository;


    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;

    }
    public List<ProductDTO> GetAll()
    {
        var products = _productRepository.GetAll();
        return products;
    }

    public ProductDTO Get(int id)
    {
        var product = _productRepository.Get(id);
        return product;
    }


    public void Add(ProductCreateDTO productCreateDTO)
    {
        var product = new Product();
        var mappedProduct = product.mapFromCreateDto(productCreateDTO);
        _productRepository.Add(mappedProduct);
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
        _productRepository.Delete(id);
    }
}


    
    

