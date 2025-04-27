using EaseShop.API.Extensions;
using EaseShop.Application.Dtos.Category;
using EaseShop.Application.Dtos.SubCategory;
using EaseShop.Application.Features.Categories.Commands.CreateCategory;
using EaseShop.Application.Features.SubCategories.Commands.CreateSubCategory;
using EaseShop.Application.Features.SubCategories.Commands.DeleteSubCategory;
using EaseShop.Application.Features.SubCategories.Commands.UpdateSubCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EaseShop.API.MinimalEndpoints.Admin;

public static class SubCategoryEndpoints
{

    public static void MapSubCategoryAdminEndpoints(this IEndpointRouteBuilder app, string baseUrl)
    {
        app.MapPost($"{baseUrl}/SubCategory", async (
                SubCategoryCreateDto subCategoryCreateDto,
                ISender sender) =>
            {
                SubCategoryCreateCommand subCategoryCreateCommand =
                    new(subCategoryCreateDto.CategoryId, subCategoryCreateDto.Name);
                var result = await sender.Send(subCategoryCreateCommand);
                return result.ToApiResult();
            })
            .WithTags("SubCategory");

        app.MapDelete($"{baseUrl}/SubCategory/{{id:int}}", async (
                int id,
                ISender sender) =>
            {
                SubCategoryDeleteCommand deleteSubCategoryCommand = new(id);
                var result = await sender.Send(deleteSubCategoryCommand);
                return result.ToApiResult();
            })
            .WithTags("SubCategory");

        app.MapPut($"{baseUrl}/SubCategory/{{id:int}}", async (
                int id,
                SubCategoryUpdateDto subCategoryUpdateDto,
                ISender sender) =>
            {
                var updateSubCategoryCommand = new UpdateSubCategoryCommand(
                    id,
                    subCategoryUpdateDto.CategoryId,
                    subCategoryUpdateDto.Name
                );
                var result = await sender.Send(updateSubCategoryCommand);
                return result.ToApiResult();
            })
            .WithTags("SubCategory");
    }
}