using FluentValidation;

namespace EaseShop.Application.Features.Auth.Commands.AppUserRegister;

public class AppUserRegisterCommandValidator : AbstractValidator<AppUserRegisterCommand>
{
    public AppUserRegisterCommandValidator()
    {
        RuleFor(p=>p.UserName)
            .NotEmpty().WithMessage("Username is required")
            .NotNull().WithMessage("Username is required")
            .MaximumLength(50).WithMessage("Username exceeds 50 characters");
        RuleFor(p=>p.FirstName)
            .NotEmpty().WithMessage("First name is required")
            .NotNull().WithMessage("First name is required")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters");
        RuleFor(p=>p.LastName)
            .NotEmpty().WithMessage("Last name is required")
            .NotNull().WithMessage("Last name is required")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters");
        RuleFor(p=>p.Email)
            .NotEmpty().WithMessage("Email is required")
            .NotNull().WithMessage("Email is required")
            .MaximumLength(100).WithMessage("Email cannot exceed 100 characters");
        RuleFor(p=>p.Password)
            .NotEmpty().WithMessage("Password is required")
            .NotNull().WithMessage("Password is required")
            .MaximumLength(64).WithMessage("Password cannot exceed 64 characters");
        RuleFor(p=>p.RePassword)
            .NotEmpty().WithMessage("Re-password is required")
            .NotNull().WithMessage("Re-password is required")
            .MaximumLength(64).WithMessage("Re-password cannot exceed 64 characters");
        RuleFor(p => p)
            .Must(p => p.Password == p.RePassword)
            .WithMessage("Passwords must match");
        
        
    }
}