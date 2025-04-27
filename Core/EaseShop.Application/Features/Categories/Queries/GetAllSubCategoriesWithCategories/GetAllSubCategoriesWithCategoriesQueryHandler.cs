using EaseShop.Application.Dtos.Category;
using EaseShop.Application.Dtos.SubCategory;
using EaseShop.Domain.Common.Pagination;
using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EaseShop.Application.Features.Categories.Queries.GetAllSubCategoriesWithCategories;

public class GetAllSubCategoriesWithCategoriesQueryHandler : IRequestHandler<GetAllSubCategoriesWithCategoriesQuery,  Result<PagedResponse<SubCategoriesWithCategoriesListItemDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSubCategoriesWithCategoriesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagedResponse<SubCategoriesWithCategoriesListItemDto>>> Handle(GetAllSubCategoriesWithCategoriesQuery request, CancellationToken cancellationToken)
    {
        var subCategoriesWithCategoriesQuery = await _unitOfWork.SubCategoryRepository.GetQuery(
            includes: query => query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Include(p=>p.Category)
            );
        var subCategoriesWithCategories = subCategoriesWithCategoriesQuery.Select(c => new SubCategoriesWithCategoriesListItemDto()
        {
            Id = c.Id,
            Name = c.Name,
            Category = new CategoryReturnDto()
            {
                Id = c.Category.Id,
                Name = c.Category.Name
            }
        }).ToList();
        var response = new PagedResponse<SubCategoriesWithCategoriesListItemDto>();
        response.Data = subCategoriesWithCategories;
        response.TotalCount = subCategoriesWithCategories.Count;
        response.PageSize = request.PageSize;
        response.CurrentPage = request.PageNumber;
        return Result<PagedResponse<SubCategoriesWithCategoriesListItemDto>>.Success(response, null);
    }
}