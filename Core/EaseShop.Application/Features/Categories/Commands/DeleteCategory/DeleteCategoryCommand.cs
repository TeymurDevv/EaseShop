using EaseShop.Domain.Common.ResultPattern;
using MediatR;

namespace EaseShop.Application.Features.Categories.Commands.DeleteCategory;

public record class DeleteCategoryCommand(Guid id) : IRequest<Result<Unit>>
{
    public Guid? Id { get; set; } = id;
}