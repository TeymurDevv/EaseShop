using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Entities;
using MediatR;

namespace EaseShop.Application.Features.SubCategories.Commands.CreateSubCategory;

public record SubCategoryCreateCommand(int categoryId, string name) : IRequest<Result<Unit>>
{
    public int CategoryId { get; set; } = categoryId;
    public string? Name { get; set; } = name;
}

public static class SubCategoryCreateMappingExtensions
{
    public static SubCategory ToEntity(this SubCategoryCreateCommand command)
    {
        return new SubCategory
        {
            CategoryId = command.CategoryId,
            Name = command.Name
        };
    }
}