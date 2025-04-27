using EaseShop.Application.Features.Categories.Commands.DeleteCategory;
using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Repositories;
using MediatR;

namespace EaseShop.Application.Features.SubCategories.Commands.DeleteSubCategory;

public class SubCategoryDeleteCommandHandler  : IRequestHandler<SubCategoryDeleteCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public SubCategoryDeleteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Unit>> Handle(SubCategoryDeleteCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.SubCategoryRepository.isExists(sc=>sc.Id == request.Id);
        if (!isExist)
            return Result<Unit>.Failure(Error.NotFound, null, ErrorType.NotFoundError);
        var existSubCategory = await _unitOfWork.SubCategoryRepository.GetEntity(sc=>sc.Id == request.Id);
        await _unitOfWork.SubCategoryRepository.Delete(existSubCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<Unit>.Success(Unit.Value,SuccessReturnType.NoContent);
    }
}