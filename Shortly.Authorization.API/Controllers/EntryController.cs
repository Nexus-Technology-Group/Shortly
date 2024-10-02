using Microsoft.AspNetCore.Mvc;

namespace Shortly.Authorization.API.Controllers;

[ApiController]
[Route("entry")]
public class EntryController : ControllerBase
{
    public EntryController()
    {
        
    }

    [HttpPatch("approve")]
    public async Task<IActionResult> Approve(CancellationToken cancellationToken)
    {
        
    }
}