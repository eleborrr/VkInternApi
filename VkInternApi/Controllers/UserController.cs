﻿using Microsoft.AspNetCore.Mvc;
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
    
    [HttpPost]
    public async Task<JsonResult> GetUserByIdAsync(int id) =>
        Json(await _userService.GetUserById(id));


    [HttpPost]
    public async Task<JsonResult> GetUsersAsync() => Json(await _userService.GetAllAsync());

    [HttpPost]
    public async Task<JsonResult> AddUserAsync([FromBody] AddUserDto dto)
    {
        return Json(await _userService.AddUser(dto));
    }
    
    [HttpPost]
    public async Task<JsonResult> DeleteUserByIdAsync([FromBody] DeleteUserDto dto)
    {
        return Json(await _userService.DeleteUser(dto));
    }
}