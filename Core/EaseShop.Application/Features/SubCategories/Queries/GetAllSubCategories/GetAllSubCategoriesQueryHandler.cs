using EaseShop.Application.Dtos.SubCategory;
using EaseShop.Domain.Common.Pagination;
using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Repositories;
using MediatR;

namespace EaseShop.Application.Features.SubCategories.Queries.GetAllSubCategories;

public class GetAllSubCategoriesQueryHandler : IRequestHandler<GetAllSubCategoriesQuery, Result<PagedResponse<SubCategoryListItemDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSubCategoriesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagedResponse<SubCategoryListItemDto>>> Handle(GetAllSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        var subCategories = await _unitOfWork.SubCategoryRepository
            .GetAll();
        var subCategoryListItemDtos = subCategories.Select(c => new SubCategoryListItemDto
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
        var response = new PagedResponse<SubCategoryListItemDto>();
        response.Data = subCategoryListItemDtos;
        response.TotalCount = subCategories.Count;
        response.PageSize = request.PageSize;
        response.CurrentPage = request.PageNumber;
        return Result<PagedResponse<SubCategoryListItemDto>>.Success(response, null);
    }
}