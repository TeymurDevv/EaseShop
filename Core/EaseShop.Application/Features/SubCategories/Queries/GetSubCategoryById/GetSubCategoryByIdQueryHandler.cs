using EaseShop.Application.Dtos.SubCategory;
using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Repositories;
using MediatR;

namespace EaseShop.Application.Features.SubCategories.Queries.GetSubCategoryById;

public class GetSubCategoryByIdQueryHandler : IRequestHandler<GetSubCategoryByIdQuery, Result<SubCategoryReturnDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSubCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SubCategoryReturnDto>> Handle(GetSubCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var isExist = await  _unitOfWork.SubCategoryRepository.isExists(sc=>sc.Id == request.Id);
        if (!isExist)
            return Result<SubCategoryReturnDto>.Failure(Error.NotFound, null, ErrorType.NotFoundError);
        var existSubCategory = await _unitOfWork.SubCategoryRepository.GetEntity(sc=>sc.Id == request.Id);
        SubCategoryReturnDto subCategoryReturnDto = new();
        subCategoryReturnDto.Id = existSubCategory.Id;
        subCategoryReturnDto.Name = existSubCategory.Name;
        return Result<SubCategoryReturnDto>.Success(subCategoryReturnDto, null);
    }
}