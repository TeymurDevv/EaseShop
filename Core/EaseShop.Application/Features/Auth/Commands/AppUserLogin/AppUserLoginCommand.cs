using EaseShop.Application.Dtos.Auth;
using EaseShop.Domain.Common.ResultPattern;
using MediatR;

namespace EaseShop.Application.Features.Auth.Commands.AppUserLogin;

public record AppUserLoginCommand(string userName, string password) : IRequest<Result<AuthResponseDto>>
{
    public string? UserName { get; set; } = userName;
    public string? Password { get; set; } = password;
}