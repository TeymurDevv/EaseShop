using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Entities;
using MediatR;

namespace EaseShop.Application.Features.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(string name) : IRequest<Result<Unit>>
{
    public string? Name { get; set; } = name;
}

public static class CategoryCreateMappingExtensions
{
    public static Category ToEntity(this CreateCategoryCommand command)
    {
        return new Category
        {
            Name = command.Name
        };
    }
}