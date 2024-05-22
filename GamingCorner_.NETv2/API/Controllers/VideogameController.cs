using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;


namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class VideogameController : ControllerBase
{
    private readonly IVideogameService _videogameService;
    public VideogameController(IVideogameService videogameService)
    {
        _videogameService = videogameService;
    }

    [HttpGet]
    public ActionResult<List<VideogameDTO>> GetAll() =>
    _videogameService.GetAll();



    [HttpGet]
    [Route("{id}")]
    public ActionResult<VideogameDTO> Get(int id)
    {
        var videogame = _videogameService.Get(id);

        if (videogame == null){
            return NotFound();
        }else{
            return videogame;
        }
    }




    [HttpPost]
    public IActionResult Create([FromBody] VideogameCreateDTO videogameCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _videogameService.Add(videogameCreateDTO);
        return Ok();
    }




    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] VideogameUpdateDTO videogameUpdateDTO)
    {
        if (!ModelState.IsValid) { return BadRequest(ModelState); }

        try
        {
            _videogameService.Update(id, videogameUpdateDTO);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }




    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = _videogameService.Get(id);

        if (user is null)
            return NotFound();

        _videogameService.Delete(id);

        return NoContent();
    }
}