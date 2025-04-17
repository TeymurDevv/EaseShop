using EaseShop.Application.Dtos.Auth;
using EaseShop.Domain.Common.ResultPattern;
using MediatR;

namespace EaseShop.Application.Features.Auth.Commands.AppUserLogin;

public record AppUserLoginCommand : IRequest<Result<AuthResponseDto>>
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
}