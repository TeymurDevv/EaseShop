using EaseShop.API.Extensions;
using EaseShop.Application.Dtos.Auth;
using EaseShop.Application.Features.Auth.Commands.AppUserLogin;
using EaseShop.Application.Features.Auth.Commands.AppUserRegister;
using MediatR;

namespace EaseShop.API.MinimalEndpoints.Client;

public static class AuthEndpoints
{
    public static void MapAuthClientEndpoints(this IEndpointRouteBuilder app, string baseUrl)
    {
        app.MapPost($"{baseUrl}Auth/Register", async (
                AppUserRegisterDto appUserRegisterDto,
                ISender sender) =>
            {
                AppUserRegisterCommand appUserRegisterCommand = new(appUserRegisterDto.UserName, appUserRegisterDto.FirstName, appUserRegisterDto.LastName, appUserRegisterDto.Email, appUserRegisterDto.Password, appUserRegisterDto.RePassword);
                var result = await sender.Send(appUserRegisterCommand);
                return result.ToApiResult();
            })
            .WithTags("Auth");
        
        app.MapPost($"{baseUrl}Auth/Login", async (
                AuthUserLoginDto authUserLoginDto,
                ISender sender) =>
            {
                AppUserLoginCommand appUserLoginCommand = new(authUserLoginDto.UserName, authUserLoginDto.Password);
                var result = await sender.Send(appUserLoginCommand);
                return result.ToApiResult();
            })
            .WithTags("Auth");
    }
}