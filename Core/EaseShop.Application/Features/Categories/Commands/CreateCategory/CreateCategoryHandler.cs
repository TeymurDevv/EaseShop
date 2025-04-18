using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Entities;
using EaseShop.Domain.Repositories;
using MediatR;

namespace EaseShop.Application.Features.Categories.Commands.CreateCategory;

public sealed class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Result<Unit>>
{
    private readonly IUnitOfWork  _unitOfWork;

    public CreateCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Unit>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.CategoryRepository.isExists(c=>c.Name == request.Name);
        if(isExist)
            return Result<Unit>.Failure(Error.Custom("AlreadyExists","Category with this name already exists."), null,ErrorType.ValidationError);
        Category newCategory = request.ToEntity();
        await _unitOfWork.CategoryRepository.Create(newCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<Unit>.Success(Unit.Value,SuccessReturnType.Created);
    }
}