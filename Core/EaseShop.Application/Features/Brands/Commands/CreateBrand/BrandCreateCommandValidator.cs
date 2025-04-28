using FluentValidation;

namespace EaseShop.Application.Features.Brands.Commands.CreateBrand;

public class BrandCreateCommandValidator  : AbstractValidator<BrandCreateCommand>
{
    public BrandCreateCommandValidator()
    {
        RuleFor(p=>p.Name)
            .NotEmpty().WithMessage("Name is required.")
            .NotNull().WithMessage("Name is required.");
    }
}