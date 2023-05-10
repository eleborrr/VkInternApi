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
        //TODO убирать blocked пользователей из поиска. Тест на пять секунд.
        await _userService.AddUser(new AddUserDto()
        {
            CreatedDate = DateTimeOffset.Now,
            Login = dto.Login,
            Password = dto.Password,
            UserStateId = 1,
            UserGroupId = 1
        });
        var passwordEncode = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(dto.Login + ":" + dto.Password));

        return Json("Basic " + passwordEncode);
    }

}