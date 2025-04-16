using EaseShop.Application.Dtos.Category;
using FluentValidation;

namespace EaseShop.Application.Validators.CategoryValidators;

public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateValidator()
    {
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