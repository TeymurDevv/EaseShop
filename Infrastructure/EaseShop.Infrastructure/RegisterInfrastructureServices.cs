using EaseShop.Application.Interfaces;
using EaseShop.Infrastructure.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resend;

namespace EaseShop.Infrastructure;

public static class RegisterInfrastructureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions();
        services.AddHttpClient<ResendClient>();
        services.Configure<ResendClientOptions>(configuration.GetSection("Resend"));

        services.AddTransient<IResend, ResendClient>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<ITokenService, TokenService>();
    }
}