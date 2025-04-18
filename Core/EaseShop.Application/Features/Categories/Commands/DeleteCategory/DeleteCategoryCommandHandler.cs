using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Entities;
using EaseShop.Domain.Repositories;
using MediatR;

namespace EaseShop.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result<Unit>>
{
    private readonly IUnitOfWork  _unitOfWork;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Unit>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var isExist =  await _unitOfWork.CategoryRepository.isExists(c=>c.Id == request.Id);
        if(!isExist)
            return Result<Unit>.Failure(Error.Custom("NotExists","Category with this id does not exists."), null,ErrorType.NotFoundError);
        Category existCategory = await _unitOfWork.CategoryRepository.GetEntity(c=>c.Id == request.Id);
        await _unitOfWork.CategoryRepository.Delete(existCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<Unit>.Success(Unit.Value,SuccessReturnType.NoContent);
    }
}