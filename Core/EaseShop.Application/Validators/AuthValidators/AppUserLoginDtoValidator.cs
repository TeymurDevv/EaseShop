using EaseShop.Application.Dtos.Auth;
using FluentValidation;

namespace EaseShop.Application.Validators.AuthValidators;

public class AppUserLoginDtoValidator : AbstractValidator<AuthUserLoginDto>
{
    public AppUserLoginDtoValidator()
    {
        RuleFor(p=>p.UserName)
            .NotNull().WithMessage("Username is required")
            .NotEmpty().WithMessage("Username is required");
        RuleFor(p=>p.Password)
            .NotNull().WithMessage("Password is required")
            .NotEmpty().WithMessage("Password is required");
    }
}