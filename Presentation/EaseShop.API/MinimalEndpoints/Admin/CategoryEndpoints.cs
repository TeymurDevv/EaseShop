using EaseShop.API.Extensions;
using EaseShop.Application.Dtos.Category;
using EaseShop.Application.Features.Categories.Commands.CreateCategory;
using EaseShop.Application.Features.Categories.Commands.DeleteCategory;
using EaseShop.Application.Features.Categories.Commands.UpdateCategory;
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
                CreateCategoryCommand createCategoryCommand = new(CategoryCreateDto.Name);
                var result = await sender.Send(createCategoryCommand);
                return result.ToApiResult();
            })
            .WithTags("Category");
        
            app.MapDelete($"{baseUrl}/Category", async (
                    Guid id,
                    ISender sender) =>
                {
                    DeleteCategoryCommand deleteCategoryCommand = new(id);
                    var result = await sender.Send(deleteCategoryCommand);
                    return result.ToApiResult();
                })
                .WithTags("Category");
            
            app.MapPut($"{baseUrl}/Category", async (
                    CategoryUpdateDto CategoryUpdateDto,
                    ISender sender) =>
                {
                    UpdateCategoryCommand updateCategoryCommand = new(CategoryUpdateDto.Id,CategoryUpdateDto.Name);
                    var result = await sender.Send(updateCategoryCommand);
                    return result.ToApiResult();
                })
                .WithTags("Category");   
    }

}