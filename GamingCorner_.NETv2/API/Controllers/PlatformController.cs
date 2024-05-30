using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;


namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class PlatformController : ControllerBase
{
    private readonly IPlatformService _platformService;
    public PlatformController(IPlatformService platformService)
    {
        _platformService = platformService;
    }

    [HttpGet]
    public ActionResult<List<PlatformDTO>> GetAll() =>
    _platformService.GetAll();



    [HttpGet]
    [Route("{id}")]
    public ActionResult<PlatformDTO> Get(int id)
    {
        var platform = _platformService.Get(id);

        if (platform == null){
            return NotFound();
        }else{
            return platform;
        }
    }




    [HttpPost]
    public IActionResult Create([FromBody] PlatformCreateDTO platformCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _platformService.Add(platformCreateDTO);
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
        var platform = _platformService.Get(id);

        if (platform is null)
            return NotFound();

        _platformService.Delete(id);

        return NoContent();
    }
}