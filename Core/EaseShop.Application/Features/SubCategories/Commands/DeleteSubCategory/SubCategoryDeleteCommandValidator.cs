using FluentValidation;

namespace EaseShop.Application.Features.SubCategories.Commands.DeleteSubCategory;

public class SubCategoryDeleteCommandValidator : AbstractValidator<SubCategoryDeleteCommand>
{
    public SubCategoryDeleteCommandValidator()
    {
        RuleFor(p=>p.Id)
            .NotNull().WithMessage("SubCategoryId cannot be null")
            .NotEmpty().WithMessage("SubCategoryId cannot be empty");
    }
}