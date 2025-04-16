using EaseShop.Application.Dtos.Category;
using FluentValidation;

namespace EaseShop.Application.Validators.CategoryValidators;

public class CategoryDeleteValidator : AbstractValidator<CategoryDeleteDto>
{
    public CategoryDeleteValidator()
    {
        RuleFor(p=>p.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
        RuleFor(p => p.Id)
            .NotEqual(Guid.Empty);
        RuleFor(p=>p.Id)
            .NotNull()
            .WithMessage("Id is required.");
    }
}