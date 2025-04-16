using Microsoft.AspNetCore.Mvc;

namespace EaseShop.API.Common;

[ApiController]
[Route("/api/[controller]")]
public abstract class BaseController : ControllerBase
{
    
}