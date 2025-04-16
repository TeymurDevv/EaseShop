using System.Linq.Expressions;
using System.Security.Claims;
using EaseShop.Application.Interfaces;
using EaseShop.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EaseShop.Persistance.AuthHandler.HttpAuth;

public class AppUserResolver : IAppUserResolver
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly UserManager<AppUser> _userManager;

    public AppUserResolver(IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
    {
        _contextAccessor = contextAccessor;
        _userManager = userManager;
    }

    public string UserId => _contextAccessor.HttpContext?.User
        .FindFirst(ClaimTypes.NameIdentifier)?.Value;

    public string UserName => _contextAccessor.HttpContext?.User
        .FindFirst(ClaimTypes.Name)?.Value;

    public bool IsAuthenticated => _contextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

    public async Task<AppUser> GetCurrentUserAsync(Expression<Func<AppUser, bool>> predicate = null,params Func<IQueryable<AppUser>, IQueryable<AppUser>>[] includes)
    {
        if (!IsAuthenticated)
            return null;
        if (string.IsNullOrEmpty(UserId))
            return null;
        var userQuery =  _userManager.Users.AsQueryable();
        if (includes != null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                userQuery = include(userQuery);
            }
        }
        if (predicate != null)
        {
            userQuery = userQuery.Where(predicate);
        }
        var currentUserInTheSystem=await userQuery.FirstOrDefaultAsync(s=>s.Id.ToString() == UserId);    
        if (currentUserInTheSystem != null)
            return currentUserInTheSystem;
        return null;
    }
}