using FluentValidation;

namespace EaseShop.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(p=>p.Id)
            .NotNull().WithMessage("Id cannot be null")
            .NotEmpty().WithMessage("Id cannot be empty");
    }
}