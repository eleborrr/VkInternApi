using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VkInternApi.Services.Auth;
using VkInternApi.Services.Auth.Attributes;

namespace VkInternApi.Controllers;

[Route("[controller]")]
public class AuthController: Controller
{
    [BasicAuthorization]
    [HttpPost("token")]
    public IActionResult Index()
    {
        return Ok();
    }
}