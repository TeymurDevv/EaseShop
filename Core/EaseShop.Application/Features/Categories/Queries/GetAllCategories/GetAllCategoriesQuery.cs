using EaseShop.Application.Dtos.Category;
using EaseShop.Domain.Common.Pagination;
using EaseShop.Domain.Common.ResultPattern;
using MediatR;

namespace EaseShop.Application.Features.Categories.Queries.GetAllCategories;

public record GetAllCategoriesQuery(int pageNumber, int pageSize) : IRequest<Result<PagedResponse<CategoryListItemDto>>>
{
    public int PageSize { get; set; } = pageSize;
    public int PageNumber { get; set; } = pageNumber;
}

