using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;


namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class VideogameOrderController : ControllerBase
{
    private readonly IVideogameOrderService _videogameOrderService;
    public VideogameOrderController(IVideogameOrderService videogameOrderService)
    {
        _videogameOrderService = videogameOrderService;
    }

    [HttpGet]
    public ActionResult<List<VideogameOrderDTO>> GetAll() =>
    _videogameOrderService.GetAll();



    [HttpGet]
    [Route("{id}")]
    public ActionResult<VideogameOrderDTO> Get(int idOrder, int idVideogame)
    {
        var videogameOrder = _videogameOrderService.Get(idOrder, idVideogame);

        if (videogameOrder == null){
            return NotFound();
        }else{
            return videogameOrder;
        }
    }




    [HttpPost]
    public IActionResult Create([FromBody] VideogameOrderCreateDTO videogameGenderCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _videogameOrderService.Add(videogameGenderCreateDTO);
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
    public IActionResult Delete(int idOrder, int idVideogame)
    {
        var videogameOrder = _videogameOrderService.Get(idOrder, idVideogame);

        if (videogameOrder is null)
            return NotFound();

        _videogameOrderService.Delete(idOrder, idVideogame);

        return NoContent();
    }
}