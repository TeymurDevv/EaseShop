using EaseShop.Domain.Enums;

namespace EaseShop.Persistance.SeedDatas;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

public class RoleSeed
{
    private static readonly string[] Roles = Enum.GetNames(typeof(Roles));

    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        foreach (var role in Roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}