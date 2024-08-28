using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class GenderController : ControllerBase
{
    private readonly IGenderService _genderService;

    public GenderController(IGenderService genderService)
    {
        _genderService = genderService;
    }

    [HttpGet]
    public ActionResult<List<GenderDTO>> GetAll() => _genderService.GetAll();

    [HttpGet]
    [Route("{id}")]
    public ActionResult<GenderDTO> Get(int id)
    {
        var gender = _genderService.Get(id);

        if (gender == null)
        {
            return NotFound();
        }
        else
        {
            return gender;
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] GenderCreateDTO genderCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _genderService.Add(genderCreateDTO);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var gender = _genderService.Get(id);

        if (gender is null)
            return NotFound();

        _genderService.Delete(id);

        return NoContent();
    }

}





