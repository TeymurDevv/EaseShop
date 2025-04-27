using EaseShop.Application.Dtos.SubCategory;
using FluentValidation;

namespace EaseShop.Application.Validators.SubCategoryValidators;

public class SubCategoryCreateValidator : AbstractValidator<SubCategoryCreateDto>
{
    public SubCategoryCreateValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Name is required")
            .NotNull().WithMessage("Name is required");
        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("CategoryId is required")
            .NotNull().WithMessage("CategoryId is required");
    }
}