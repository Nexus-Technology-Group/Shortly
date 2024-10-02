using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shortly.Authorization.API.Controllers;

[ApiController]
[Route("authorization")]
public class AuthorizationController : ControllerBase
{
    
    public AuthorizationController()
    {
        
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(CancellationToken cancellationToken)
    {
        
    }

    [HttpPatch("logout")]
    [Authorize]
    public async Task<IActionResult> Logout(CancellationToken cancellationToken)
    {
        
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(CancellationToken cancellationToken)
    {
        
    }
}