using EaseShop.Domain.Common.ResultPattern;
using MediatR;

namespace EaseShop.Application.Features.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(Guid id, string name) : IRequest<Result<Unit>>
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
}