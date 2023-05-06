using Microsoft.AspNetCore.Mvc;
using VkInternApi.Services.Auth.Attributes;

namespace VkInternApi.Controllers;

[Route("[controller]")]
public class UserController: Controller
{
    [BasicAuthorization]
    [HttpPost]
    public IActionResult GetUserByIdAsync()
    {
        return Ok();
    }
    
    [BasicAuthorization]
    [HttpPost]
    public IActionResult GetUsersAsync()
    {
        return Ok();
    }
    
    [BasicAuthorization]
    [HttpPost]
    public IActionResult AddUserAsync()
    {
        return Ok();
    }
    
    [BasicAuthorization]
    [HttpPost]
    public IActionResult DeleteUserByIdAsync()
    {
        return Ok();
    }
}