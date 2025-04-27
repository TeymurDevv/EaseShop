using EaseShop.Application.Dtos.SubCategory;
using EaseShop.Domain.Common.Pagination;
using EaseShop.Domain.Common.ResultPattern;
using MediatR;

namespace EaseShop.Application.Features.SubCategories.Queries.GetAllSubCategories;

public record GetAllSubCategoriesQuery(int pageNumber, int pageSize) : IRequest<Result<PagedResponse<SubCategoryListItemDto>>>
{
    public int PageSize { get; set; } = pageSize;
    public int PageNumber { get; set; } = pageNumber;
}