using EaseShop.Application.Dtos.SubCategory;
using EaseShop.Domain.Common.ResultPattern;
using MediatR;

namespace EaseShop.Application.Features.SubCategories.Queries.GetSubCategoryById;

public record GetSubCategoryByIdQuery(int id) : IRequest<Result<SubCategoryReturnDto>>
{
    public int Id { get; set; } = id;
}