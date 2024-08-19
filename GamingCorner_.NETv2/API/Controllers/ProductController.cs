using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;


namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<List<ProductDTO>> GetAll() =>
    _productService.GetAll();



    [HttpGet]
    [Route("{id}")]
    public ActionResult<ProductDTO> Get(int id)
    {
        var gender = _productService.Get(id);

        if (gender == null){
            return NotFound();
        }else{
            return gender;
        }
    }




    [HttpPost]
    public IActionResult Create([FromBody] ProductCreateDTO genderCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _productService.Add(genderCreateDTO);
        return Ok();
    }




    // [HttpPut("{id}")]
    // public IActionResult Update(int id, [FromBody] VideogameUpdateDTO videogameUpdateDTO)
    // {
    //     if (!ModelState.IsValid) { return BadRequest(ModelState); }

    //     try
    //     {
    //         _genderService.Update(id, videogameUpdateDTO);
    //         return NoContent();
    //     }
    //     catch (KeyNotFoundException)
    //     {
    //         return NotFound();
    //     }
    // }




    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = _productService.Get(id);

        if (user is null)
            return NotFound();

        _productService.Delete(id);

        return NoContent();
    }
}