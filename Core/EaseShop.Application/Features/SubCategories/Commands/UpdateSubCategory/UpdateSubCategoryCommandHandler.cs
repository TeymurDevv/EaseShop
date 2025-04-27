using EaseShop.Application.Features.Categories.Commands.UpdateCategory;
using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Repositories;
using MediatR;

namespace EaseShop.Application.Features.SubCategories.Commands.UpdateSubCategory;

public class UpdateSubCategoryCommandHandler  : IRequestHandler<UpdateSubCategoryCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSubCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Unit>> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
    {
        var existSubCategory = await _unitOfWork.SubCategoryRepository.GetEntity(sc=>sc.Id == request.Id);
        if (existSubCategory is null)
            return Result<Unit>.Failure(Error.NotFound, null, ErrorType.NotFoundError);
        var existSubCategoryWithName = await _unitOfWork.SubCategoryRepository.GetEntity(c => c.Name == request.Name && c.Id != request.Id);
        if (existSubCategoryWithName is not null)
            return Result<Unit>.Failure(Error.DuplicateConflict, null, ErrorType.ValidationError);
        var existCategoryWithId = await _unitOfWork.CategoryRepository.isExists(c => c.Id == request.CategoryId);
        if (!existCategoryWithId)
            return Result<Unit>.Failure(Error.Custom("NotFound","Category not found with this id"), null, ErrorType.NotFoundError);
        if (!string.IsNullOrWhiteSpace(request.Name))
            existSubCategory.Name = request.Name ?? existSubCategory.Name;
        existSubCategory.CategoryId = request.CategoryId;
        await _unitOfWork.SubCategoryRepository.Update(existSubCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<Unit>.Success(Unit.Value, SuccessReturnType.NoContent);
    }
}