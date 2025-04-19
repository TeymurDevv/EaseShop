using FluentValidation;

namespace EaseShop.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdQueryValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Id is required.")
            .NotNull().WithMessage("Id is required.");
    }
}