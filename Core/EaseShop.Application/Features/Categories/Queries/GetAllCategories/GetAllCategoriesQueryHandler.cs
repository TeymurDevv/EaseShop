using EaseShop.Application.Dtos.Category;
using EaseShop.Domain.Common.Pagination;
using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Repositories;
using MediatR;

namespace EaseShop.Application.Features.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, Result<PagedResponse<CategoryListItemDto>>>
{
    private readonly IUnitOfWork  _unitOfWork;

    public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PagedResponse<CategoryListItemDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _unitOfWork.CategoryRepository.GetAll();
        var categoryListItemDtos = categories.Select(c => new CategoryListItemDto
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
        var response = new PagedResponse<CategoryListItemDto>();
        response.Data = categoryListItemDtos;
        response.TotalCount = categories.Count;
        response.PageSize = request.PageSize;
        response.CurrentPage = request.PageNumber;
        return Result<PagedResponse<CategoryListItemDto>>.Success(response, null);
    }
}