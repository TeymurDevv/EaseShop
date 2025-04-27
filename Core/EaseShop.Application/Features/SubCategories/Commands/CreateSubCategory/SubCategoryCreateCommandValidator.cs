using FluentValidation;

namespace EaseShop.Application.Features.SubCategories.Commands.CreateSubCategory;

public class SubCategoryCreateCommandValidator : AbstractValidator<SubCategoryCreateCommand>
{
    public SubCategoryCreateCommandValidator()
    {
        RuleFor(p=>p.categoryId)
            .NotEmpty().WithMessage("CategoryId is required.")
            .NotNull().WithMessage("CategoryId is required.");
        RuleFor(p=>p.Name)
            .NotEmpty().WithMessage("Name is required.")
            .NotNull().WithMessage("Name is required.");
    }
}