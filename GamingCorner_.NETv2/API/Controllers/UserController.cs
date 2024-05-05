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
    public ActionResult<List<User>> GetAll() =>
    _userService.GetAll();



    [HttpGet]
    [Route("{id}")]
    public ActionResult<User> Get(int id)
    {
        var user = _userService.Get(id);

        if (user == null){
            return NotFound();
        }else{
            return user;
        }
    }




    [HttpPost]
    public IActionResult Create(User user)
    {
        _userService.Add(user);
        return CreatedAtAction(nameof(Get), new { id = user.ObraId }, user);
    }




    [HttpPut("{id}")]
    public IActionResult Update(int id, User user)
    {
        if (id != user.ObraId)
            return BadRequest();

        var existingObra = _userService.Get(id);
        if (existingObra is null)
            return NotFound();

        _userService.Update(user);

        return NoContent();
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