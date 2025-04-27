using FluentValidation;

namespace EaseShop.Application.Features.SubCategories.Queries.GetSubCategoryById;

public class GetSubCategoryByIdQueryValidator : AbstractValidator<GetSubCategoryByIdQuery>
{
    public GetSubCategoryByIdQueryValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("Id is required.")
            .NotNull().WithMessage("Id is required.");
    }
}