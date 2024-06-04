using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;


namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class ConsoleOrderController : ControllerBase
{
    private readonly IConsoleOrderService _consoleOrderService;
    public ConsoleOrderController(IConsoleOrderService consoleOrderService)
    {
        _consoleOrderService = consoleOrderService;
    }

    [HttpGet]
    public ActionResult<List<ConsoleOrderDTO>> GetAll() =>
    _consoleOrderService.GetAll();



    [HttpGet]
    [Route("{id}")]
    public ActionResult<ConsoleOrderDTO> Get(int idConsole, int idOrder)
    {
        var consoleOrder = _consoleOrderService.Get(idConsole, idOrder);

        if (consoleOrder == null){
            return NotFound();
        }else{
            return consoleOrder;
        }
    }




    [HttpPost]
    public IActionResult Create([FromBody] ConsoleOrderCreateDTO consoleOrderCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _consoleOrderService.Add(consoleOrderCreateDTO);
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
    public IActionResult Delete(int idConsole, int idOrder)
    {
        var consoleOrder = _consoleOrderService.Get(idConsole, idOrder);

        if (consoleOrder is null)
            return NotFound();

        _consoleOrderService.Delete(idConsole, idOrder);

        return NoContent();
    }
}