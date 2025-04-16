using FluentValidation;

namespace EaseShop.Application.Features.Categories.Commands.CreateCategory;

public sealed class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
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