using EaseShop.Application.Dtos.SubCategory;
using EaseShop.Domain.Common.Pagination;
using EaseShop.Domain.Common.ResultPattern;
using MediatR;

namespace EaseShop.Application.Features.Categories.Queries.GetAllSubCategoriesWithCategories;

public class GetAllSubCategoriesWithCategoriesQuery(int pageNumber, int pageSize)  : IRequest<Result<PagedResponse<SubCategoriesWithCategoriesListItemDto>>>
{
    public int PageSize { get; set; } = pageSize;
    public int PageNumber { get; set; } = pageNumber;
}