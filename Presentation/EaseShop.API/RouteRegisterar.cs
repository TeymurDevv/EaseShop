using EaseShop.API.MinimalEndpoints.Client;

namespace EaseShop.API;

public static class RouteRegisterar
{
    public static void RegisterRoutes(this IEndpointRouteBuilder app,IConfiguration configuration)
    {
        var baseAdminUrl = configuration["ApiSettings:BaseAdminUrl"];
        var clientSideUrl=configuration["ApiSettings:ClientSideUrl"];
        app.MapAuthClientEndpoints(clientSideUrl);
    }
}