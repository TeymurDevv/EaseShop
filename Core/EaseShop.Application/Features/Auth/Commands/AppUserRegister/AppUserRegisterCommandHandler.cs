using EaseShop.Application.Interfaces;
using EaseShop.Domain.Common.ResultPattern;
using EaseShop.Domain.Entities;
using EaseShop.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace EaseShop.Application.Features.Auth.Commands.AppUserRegister;

public class AppUserRegisterCommandHandler  : IRequestHandler<AppUserRegisterCommand, Result<Unit>>
{
    private readonly IEmailService  _emailService;
    private readonly UserManager<AppUser> _userManager;

    public AppUserRegisterCommandHandler(IEmailService emailService, UserManager<AppUser> userManager)
    {
        _emailService = emailService;
        _userManager = userManager;
    }

    public async Task<Result<Unit>> Handle(AppUserRegisterCommand request, CancellationToken cancellationToken)
    {
        AppUser appUserResult = request.ToEntity();
        IdentityResult identityResult = await _userManager.CreateAsync(appUserResult, request.Password);
        if (!identityResult.Succeeded)
        {
            var errors = identityResult.Errors.Select(e => e.Description).ToList();
            return Result<Unit>.Failure(Error.ValidationFailed, errors, ErrorType.ValidationError);
        }
        await _userManager.AddToRoleAsync(appUserResult, Roles.member.ToString());
        return Result<Unit>.Success(Unit.Value,SuccessReturnType.Created);
    }
}