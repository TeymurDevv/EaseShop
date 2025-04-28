using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Entities;
using EaseShop.Domain.Repositories;
using MediatR;

namespace EaseShop.Application.Features.Brands.Commands.CreateBrand;

public class BrandCreateCommandHandler : IRequestHandler<BrandCreateCommand, Result<Unit>>
{
    private readonly IUnitOfWork  _unitOfWork;

    public BrandCreateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Unit>> Handle(BrandCreateCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _unitOfWork.BrandRepository.isExists(b => b.Name.ToLower() == request.Name.ToLower());
        if (isExist)
            return Result<Unit>.Failure(Error.DuplicateConflict, null, ErrorType.ValidationError);
        Brand newBrand = request.ToEntity();
        await _unitOfWork.BrandRepository.Create(newBrand);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<Unit>.Success(Unit.Value,SuccessReturnType.Created);
    }
}