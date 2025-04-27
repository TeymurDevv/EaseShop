using EaseShop.Domain.Common.ResultPattern;
using MediatR;

namespace EaseShop.Application.Features.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(int id, string name) : IRequest<Result<Unit>>
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}