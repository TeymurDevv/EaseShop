using EaseShop.API.Extensions;
using EaseShop.Application.Dtos.Category;
using EaseShop.Application.Features.Categories.Commands.CreateCategory;
using EaseShop.Application.Features.Categories.Commands.DeleteCategory;
using MediatR;

namespace EaseShop.API.MinimalEndpoints.Admin;

public static class CategoryEndpoints
{
    public static void MapCategoryAdminEndpoints(this IEndpointRouteBuilder app, string baseUrl)
    {
        app.MapPost($"{baseUrl}/Category", async (
                CategoryCreateDto CategoryCreateDto,
                ISender sender) =>
            {
                CreateCategoryCommand createCategoryCommand = new();
                createCategoryCommand.Name = CategoryCreateDto.Name;
                var result = await sender.Send(createCategoryCommand);
                return result.ToApiResult();
            })
            .WithTags("Category");
        
            app.MapDelete($"{baseUrl}/Category", async (
                    Guid id,
                    ISender sender) =>
                {
                    DeleteCategoryCommand deleteCategoryCommand = new();
                    deleteCategoryCommand.Id = id;
                    var result = await sender.Send(deleteCategoryCommand);
                    return result.ToApiResult();
                })
                .WithTags("Category");        
    }

}