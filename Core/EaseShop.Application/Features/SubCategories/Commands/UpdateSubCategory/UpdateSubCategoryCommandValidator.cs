using FluentValidation;

namespace EaseShop.Application.Features.SubCategories.Commands.UpdateSubCategory;

public class UpdateSubCategoryCommandValidator : AbstractValidator<UpdateSubCategoryCommand>
{
    public UpdateSubCategoryCommandValidator()
    {
        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("CategoryId is required.")
            .NotNull().WithMessage("CategoryId is required.");
        RuleFor(p=>p.Id)
            .NotEmpty().WithMessage("Id is required.")
            .NotNull().WithMessage("Id is required.");
    }
}