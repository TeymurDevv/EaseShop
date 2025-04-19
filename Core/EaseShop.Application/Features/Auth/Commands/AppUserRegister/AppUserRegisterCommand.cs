using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Entities;
using MediatR;

namespace EaseShop.Application.Features.Auth.Commands.AppUserRegister;

public record AppUserRegisterCommand(string userName, string firstName, string lastName, string email, string password, string rePassword) : IRequest<Result<Unit>>
{
    public string? UserName { get; set; } = userName;
    public string? FirstName { get; set; } = firstName;
    public string? LastName { get; set; } = lastName;
    public string? Email { get; set; } = email;
    public string? Password { get; set; } = password;
    public string? RePassword { get; set; } = rePassword;
}



public static class AppUserRegisterMappingExtensions
{
    public static AppUser ToEntity(this AppUserRegisterCommand command)
    {
        return new AppUser
        {
            UserName = command.UserName,
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
        };
    }
}