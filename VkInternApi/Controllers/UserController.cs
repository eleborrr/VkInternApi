using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VkInternApi.Data;
using VkInternApi.Entities;
using VkInternApi.Services.Auth.Attributes;

namespace VkInternApi.Controllers;

[Route("[controller]")]
public class UserController: Controller
{
    private ApplicationDbContext _dbContext;
    
    public UserController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
        
    
    [BasicAuthorization]
    [HttpPost]
    public async Task<JsonResult> GetUserByIdAsync(int id) =>
        Json(await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id));


    [BasicAuthorization]
    [HttpPost]
    public async Task<JsonResult> GetUsersAsync() => Json(_dbContext.Users);

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