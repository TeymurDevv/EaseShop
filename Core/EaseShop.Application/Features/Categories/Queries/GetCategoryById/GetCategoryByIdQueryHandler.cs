using EaseShop.Application.Dtos.Category;
using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Repositories;
using MediatR;

namespace EaseShop.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<CategoryReturnDto>>
{
    private readonly IUnitOfWork  _unitOfWork;

    public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CategoryReturnDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.CategoryRepository.isExists(c=>c.Id == request.Id);
        if(!isExist)
            return Result<CategoryReturnDto>.Failure(Error.Custom("NotFound","Category not found with this Id."),null,ErrorType.NotFoundError);
        var existCategory = await _unitOfWork.CategoryRepository.GetEntity(c=>c.Id == request.Id);
        CategoryReturnDto categoryReturnDto = new CategoryReturnDto();
        categoryReturnDto.Id = existCategory.Id;
        categoryReturnDto.Name = existCategory.Name;
        return Result<CategoryReturnDto>.Success(categoryReturnDto,null);
    }
}