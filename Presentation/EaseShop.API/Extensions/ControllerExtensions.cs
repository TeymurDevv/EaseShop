using EaseShop.Domain.Common.ResultPattern;
using Microsoft.AspNetCore.Mvc;

namespace EaseShop.API.Extensions;

public static class ControllerExtensions
{
    public static IActionResult ToActionResult<T>(this ControllerBase controller, Result<T> result)
    {
        if (!result.IsSuccess)
        {
            return result.ErrorType switch
            {
                ErrorType.NotFoundError => controller.NotFound(result),
                ErrorType.ValidationError => controller.BadRequest(result),
                ErrorType.UnauthorizedError => controller.Unauthorized(result),
                _ => controller.StatusCode(500, result)
            };
        }

        return result.SuccessReturnType switch
        {
            SuccessReturnType.NoContent => controller.NoContent(),
            SuccessReturnType.Created => controller.Created(),
            _ => controller.Ok(result)
        };
    }   
    public static IResult ToApiResult<T>(this Result<T> result)
    {
        if (!result.IsSuccess)
        {
            return result.ErrorType switch
            {
                ErrorType.NotFoundError => Results.NotFound(result),
                ErrorType.ValidationError => Results.BadRequest(result),
                ErrorType.UnauthorizedError => Results.Unauthorized(),
                _ => Results.InternalServerError(result)
            };
        }
        
        return result.SuccessReturnType switch
        {
            SuccessReturnType.NoContent => Results.NoContent(),
            SuccessReturnType.Created => Results.Created(),
            _ => Results.Ok(result)
        };
        
    }

}