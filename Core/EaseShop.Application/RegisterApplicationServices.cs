using EaseShop.Application.Features.Categories.Commands.CreateCategory;
using EaseShop.Application.Validators.CategoryValidators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EaseShop.Application;

public static class RegisterApplicationServices
{
    public static void ApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters()
            .AddValidatorsFromAssemblyContaining<CategoryCreateValidator>();
        
        services.AddHangfire(x => x.UseSqlServerStorage(configuration.GetConnectionString("AppConnectionString")));
        services.AddHangfireServer();
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(CreateCategoryHandler).Assembly);
        });
        services.AddResponseCompression(opt =>
        {
            opt.EnableForHttps = true;
            opt.Providers.Add<BrotliCompressionProvider>();
            opt.Providers.Add<GzipCompressionProvider>();
        });
    }
}