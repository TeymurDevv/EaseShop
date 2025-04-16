using EaseShop.API.Extensions;
using EaseShop.Application.Dtos.Auth;
using EaseShop.Application.Features.Auth.Commands.AppUserRegister;
using FluentValidation;
using MediatR;

namespace EaseShop.API.MinimalEndpoints.Client;

public static class AuthEndpoints
{
    public static void MapAuthClientEndpoints(this IEndpointRouteBuilder app, string baseUrl)
    {
        app.MapPost($"{baseUrl}Auth/Register", async (
                AppUserRegisterDto appUserRegisterDto,
                ISender _sender) =>
            {
                AppUserRegisterCommand appUserRegisterCommand = new();
                appUserRegisterCommand.UserName = appUserRegisterDto.UserName;
                appUserRegisterCommand.FirstName = appUserRegisterDto.FirstName;
                appUserRegisterCommand.LastName = appUserRegisterDto.LastName;
                appUserRegisterCommand.Email = appUserRegisterDto.Email;
                appUserRegisterCommand.Password = appUserRegisterDto.Password;
                appUserRegisterCommand.RePassword = appUserRegisterDto.RePassword;
                var result = await _sender.Send(appUserRegisterCommand);
                return result.ToApiResult();
            })
            .WithTags("RegisterUser");
    }
}