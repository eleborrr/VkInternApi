using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using VkInternApi.Data;
using VkInternApi.Data.Dto;
using VkInternApi.Entities;
using VkInternApi.Services.Auth.Attributes;
using VkInternApi.Services.User;

namespace VkInternApi.Controllers;

[Route("[controller]")]
[BasicAuthorization]
public class UserController: Controller
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("/getUser")]
    public async Task<JsonResult> GetUserByIdAsync([FromQuery] int id) =>
        Json(await _userService.GetUserById(id));


    [HttpPost("/getAllUsers")]
    public async Task<JsonResult> GetUsersAsync([FromQuery] UserParameters userParameters) => Json(await _userService.GetAllAsync(userParameters));

    [HttpPost("/addUser")]
    public async Task<JsonResult> AddUserAsync([FromBody] AddUserDto dto)
    {
        var result = await _userService.AddUser(dto);
        return new JsonResult(new { message = result.Message }) { StatusCode = result.StatusCode };
    }
    
    [HttpPost("/deleteUser")]
    public async Task<JsonResult> DeleteUserByIdAsync([FromBody] DeleteUserDto dto)
    {
        var result = await _userService.DeleteUser(dto);
        return new JsonResult(new { message = result.Message }) { StatusCode = result.StatusCode };
    }
}