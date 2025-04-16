namespace EaseShop.Application.Features.Categories.Commands.CreateCategory;

public sealed record CreateCategoryCommand
{
    public required string Name { get; set; }
}