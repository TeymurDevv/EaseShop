using EaseShop.Application.Dtos.Category;
using FluentValidation;

namespace EaseShop.Application.Validators.CategoryValidators;

public class CaategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
{
    public CaategoryUpdateValidator()
    {
        RuleFor(p=>p.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
        RuleFor(p => p.Id)
            .NotEqual(Guid.Empty);
        RuleFor(p=>p.Id)
            .NotNull()
            .WithMessage("Id is required.");
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.");
        RuleFor(p=>p.Name)
            .MinimumLength(3)
            .WithMessage("Name must be at least 3 characters long.");
        RuleFor(p=>p.Name)
            .MaximumLength(100)
            .WithMessage("Name must be less than 100 characters long.");
        RuleFor(p=>p.Name)
            .NotNull()
            .WithMessage("Name is required.");
    }
}