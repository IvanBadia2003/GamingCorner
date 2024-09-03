using System.Security.Claims;
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

    [HttpGet("get-chat-users")]
    public IActionResult GetChatUsers(int productId)
    {
        try
        {
            // Obtén el ID del usuario autenticado desde el token de autenticación
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            // Llama al servicio para obtener los datos del usuario actual y el vendedor
            (UserDTO currentUser, UserDTO sellerUser) = _userService.PrepareChatUsers(currentUserId, productId);

            // Devuelve los datos en la respuesta HTTP
            return Ok(new
            {
                CurrentUser = currentUser,
                SellerUser = sellerUser
            });
        }
        catch (KeyNotFoundException ex)
        {
            // Si ocurre una excepción de KeyNotFound, devolvemos un 404 NotFound
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public ActionResult<List<UserDTO>> GetAll() => _userService.GetAll();

    [HttpGet]
    [Route("{id}")]
    public ActionResult<UserDTO> Get(int id)
    {
        var user = _userService.Get(id);

        if (user == null)
        {
            return NotFound();
        }
        else
        {
            return user;
        }
    }

    [HttpGet]
    [Route("{id}/transactions")]
    public ActionResult<List<TransactionDTO>> GetTransactionsByUser(int id)
    {
        var transactions = _userService.GetTransactionsByUser(id);

        if (transactions == null || transactions.Count == 0)
        {
            return NotFound();
        }
        return Ok(transactions);


    }

    [HttpPost]
    public IActionResult Create([FromBody] UserCreateDTO userCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
             _userService.Add(userCreateDTO);
             return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
        
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UserUpdateDTO userUpdateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

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

    [HttpPost("login")] // Ruta del endpoint para el inicio de sesión
    public IActionResult Login([FromBody] UserLoginDTO userLoginDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Llama al servicio de autenticación para manejar el inicio de sesión
        var user = _userService.Login(userLoginDTO.Email, userLoginDTO.Password);

        if (user == null)
        {
            return Unauthorized(); // Devuelve un Unauthorized si las credenciales son inválidas
        }

        // Devuelve un Ok con el objeto UserDTO si el inicio de sesión es exitoso
        return Ok(user);
    }

    //     [HttpGet("buyer/{buyerId}/seller/{sellerId}")]
    // public ActionResult GetChatDetails(string buyerId, string sellerId)
    // {
    //     var buyer = _userService.Get(buyerId); // Implementa esta función en tu servicio para obtener el usuario comprador
    //     var seller = _userService.Get(sellerId); // Implementa esta función en tu servicio para obtener el usuario vendedor

    //     if (buyer == null || seller == null)
    //     {
    //         return NotFound();
    //     }
    //     else
    //     {
    //         return buyer;
    //         return seller;
    //     }
    // }

    //     [HttpGet("buyer/{buyerId}/seller/{sellerId}")]
    // public IActionResult GetChatDetails(int buyerId, int sellerId)
    // {
    //     var buyer = _userService.Get(buyerId); // Implementa esta función en tu servicio para obtener el usuario comprador
    //     var seller = _userService.Get(sellerId); // Implementa esta función en tu servicio para obtener el usuario vendedor

    //     if (buyer == null || seller == null)
    //     {
    //         return NotFound();
    //     }

    //     var chatDetails = new
    //     {
    //         buyer = new
    //         {
    //             id = buyer.Id,
    //             name = buyer.Name,
    //             email = buyer.Email
    //         },
    //         seller = new
    //         {
    //             id = seller.Id,
    //             name = seller.Name,
    //             email = seller.Email
    //         }
    //     };

    //     return Ok(chatDetails);
    // }




}





