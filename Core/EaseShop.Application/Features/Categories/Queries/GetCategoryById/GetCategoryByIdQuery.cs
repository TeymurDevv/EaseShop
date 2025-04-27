using EaseShop.Application.Dtos.Category;
using EaseShop.Domain.Common.ResultPattern;
using MediatR;

namespace EaseShop.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQuery(int id) : IRequest<Result<CategoryReturnDto>>
{
    public int Id { get; set; } = id;
}