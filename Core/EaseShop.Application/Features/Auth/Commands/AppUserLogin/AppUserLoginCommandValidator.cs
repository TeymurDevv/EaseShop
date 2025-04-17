using FluentValidation;

namespace EaseShop.Application.Features.Auth.Commands.AppUserLogin;

public class AppUserLoginCommandValidator : AbstractValidator<AppUserLoginCommand>
{
    public AppUserLoginCommandValidator()
    {
        RuleFor(p=>p.UserName)
            .NotNull().WithMessage("Username is required")
            .NotEmpty().WithMessage("Username is required");
        RuleFor(p=>p.Password)
            .NotNull().WithMessage("Password is required")
            .NotEmpty().WithMessage("Password is required");
    }
}