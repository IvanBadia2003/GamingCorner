using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;


namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class SecondHandController : ControllerBase
{
    private readonly ISecondHandService _secondHandService;
    public SecondHandController(ISecondHandService secondHandService)
    {
        _secondHandService = secondHandService;
    }

    [HttpGet]
    public ActionResult<List<SecondHandDTO>> GetAll() =>
    _secondHandService.GetAll();



    [HttpGet]
    [Route("{id}")]
    public ActionResult<SecondHandDTO> Get(int idSecondHand)
    {
        var secondHand = _secondHandService.Get(idSecondHand);

        if (secondHand == null){
            return NotFound();
        }else{
            return secondHand;
        }
    }




    [HttpPost]
    public IActionResult Create([FromBody] SecondHandCreateDTO secondHandCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _secondHandService.Add(secondHandCreateDTO);
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
    public IActionResult Delete(int idSecondHand)
    {
        var secondHand = _secondHandService.Get(idSecondHand);

        if (secondHand is null)
            return NotFound();

        _secondHandService.Delete(idSecondHand);

        return NoContent();
    }
}