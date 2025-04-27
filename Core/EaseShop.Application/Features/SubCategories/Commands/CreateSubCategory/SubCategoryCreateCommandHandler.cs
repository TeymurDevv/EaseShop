using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Repositories;
using MediatR;

namespace EaseShop.Application.Features.SubCategories.Commands.CreateSubCategory;

public class SubCategoryCreateCommandHandler  : IRequestHandler<SubCategoryCreateCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public SubCategoryCreateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Unit>> Handle(SubCategoryCreateCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.SubCategoryRepository.isExists(c=>c.Name.ToLower() == request.Name.ToLower() && c.CategoryId == request.CategoryId);
        if (isExist)
            return Result<Unit>.Failure(Error.DuplicateConflict, null, ErrorType.ValidationError);
        var isCategoryExist = await _unitOfWork.CategoryRepository.isExists(c=>c.Id==request.CategoryId);
        if (!isCategoryExist)
            return Result<Unit>.Failure(Error.Custom("CategoryNotFound","Category not found with this Id."), null, ErrorType.ValidationError);
        var newSubCategory = request.ToEntity();
        await _unitOfWork.SubCategoryRepository.Create(newSubCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<Unit>.Success(Unit.Value, SuccessReturnType.Created);
    }
}