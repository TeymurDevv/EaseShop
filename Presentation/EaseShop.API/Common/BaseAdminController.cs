using Microsoft.AspNetCore.Mvc;

namespace EaseShop.API.Common;

[ApiController]
[Area("Admin")]
[Route("api/[area]/[controller]")]
public abstract class BaseAdminController : ControllerBase
{
    
}