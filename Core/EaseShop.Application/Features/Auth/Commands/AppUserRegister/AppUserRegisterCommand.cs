using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Entities;
using MediatR;

namespace EaseShop.Application.Features.Auth.Commands.AppUserRegister;

public record AppUserRegisterCommand : IRequest<Result<Unit>>
{
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? RePassword { get; set; }
}



public static class AppUserMappingExtensions
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