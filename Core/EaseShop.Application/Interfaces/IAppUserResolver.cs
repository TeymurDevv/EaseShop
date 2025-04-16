using System.Linq.Expressions;
using EaseShop.Domain.Entities;

namespace EaseShop.Application.Interfaces;

public interface IAppUserResolver
{
    public interface IAppUserResolver
    {
        string UserId { get; }
        string UserName { get; }
        bool IsAuthenticated { get; }

        Task<AppUser> GetCurrentUserAsync(Expression<Func<AppUser, bool>> predicate = null,params Func<IQueryable<AppUser>, IQueryable<AppUser>>[] includes);

    }
}