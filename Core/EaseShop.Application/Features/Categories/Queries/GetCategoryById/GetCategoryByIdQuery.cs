using EaseShop.Application.Dtos.Category;
using EaseShop.Domain.Common.ResultPattern;
using MediatR;

namespace EaseShop.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQuery(Guid id) : IRequest<Result<CategoryReturnDto>>
{
    public Guid Id { get; set; } = id;
}