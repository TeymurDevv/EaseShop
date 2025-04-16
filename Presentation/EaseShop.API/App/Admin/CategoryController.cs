using EaseShop.API.Common;
using Microsoft.AspNetCore.Mvc;

namespace EaseShop.API.App.Admin;

public class CategoryController : BaseAdminController
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllCategories()
    {
        return Ok();
    }
}