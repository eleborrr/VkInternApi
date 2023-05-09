using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VkInternApi.Data.Dto;
using VkInternApi.Entities;
using VkInternApi.Services.Auth;
using VkInternApi.Services.Auth.Attributes;
using VkInternApi.Services.User;

namespace VkInternApi.Controllers;

[Route("[controller]")]
public class AuthController: Controller
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("/register")]
    public async Task<JsonResult> Register([FromBody] RegisterDto dto)
    {
        await _userService.AddUser(new AddUserDto()
        {
            CreatedDate = DateTime.Now,
            Login = dto.Login,
            Password = dto.Password,
        });
        // var passwordEncode = Convert.ToBase64String(dto.Password);

        return Json("Ok");
    }
    
    // [HttpPost("/login")]
    // public async Task<JsonResult> Login()
    // {
    //     return Json("asd");
    // }
    
}