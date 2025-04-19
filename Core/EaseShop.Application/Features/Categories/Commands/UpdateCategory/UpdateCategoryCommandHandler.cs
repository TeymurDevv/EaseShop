using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Repositories;
using MediatR;

namespace EaseShop.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Unit>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var existCategory = await  _unitOfWork.CategoryRepository.GetEntity(c => c.Id == request.Id);
        if (existCategory is null)
            return Result<Unit>.Failure(Error.NotFound, null, ErrorType.NotFoundError);
        var existCategoryWithName = await _unitOfWork.CategoryRepository.GetEntity(c => c.Name == request.Name && c.Id != request.Id);
        if (existCategoryWithName is not null)
            return Result<Unit>.Failure(Error.NotFound, null, ErrorType.NotFoundError);
        if (string.IsNullOrWhiteSpace(existCategory.Name))
            existCategory.Name = request.Name ?? existCategory.Name;
        await _unitOfWork.CategoryRepository.Update(existCategory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<Unit>.Success(Unit.Value, SuccessReturnType.NoContent);
    }
}