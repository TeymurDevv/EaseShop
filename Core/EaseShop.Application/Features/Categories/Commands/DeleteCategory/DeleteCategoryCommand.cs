using EaseShop.Domain.Common.ResultPattern;
using MediatR;

namespace EaseShop.Application.Features.Categories.Commands.DeleteCategory;

public record class DeleteCategoryCommand(int id) : IRequest<Result<Unit>>
{
    public int Id { get; set; } = id;
}