using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.AspNetCore.Mvc;


namespace GamingCorner.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<List<UserDTO>> GetAll() =>
    _userService.GetAll();



    [HttpGet]
    [Route("{id}")]
    public ActionResult<UserDTO> Get(int id)
    {
        var user = _userService.Get(id);

        if (user == null){
            return NotFound();
        }else{
            return user;
        }
    }




    [HttpPost]
    public IActionResult Create([FromBody] UserCreateDTO userCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        _userService.Add(userCreateDTO);
        return Ok();
    }




    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UserUpdateDTO userUpdateDTO)
    {
        if (!ModelState.IsValid) { return BadRequest(ModelState); }

        try
        {
            _userService.Update(id, userUpdateDTO);
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
        var user = _userService.Get(id);

        if (user is null)
            return NotFound();

        _userService.Delete(id);

        return NoContent();
    }
}