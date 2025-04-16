using EaseShop.API;
using EaseShop.Application;
using EaseShop.Domain.Entities;
using EaseShop.Infrastructure;
using EaseShop.Persistance;
using EaseShop.Persistance.Data;
using EaseShop.Persistance.SeedDatas;
using Hangfire;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var config = builder.Configuration;
builder.Services.RegisterServices(config);
builder.Services.AddPersistenceServices(config);
builder.Services.AddInfrastructureServices(config);
builder.Services.ApplicationServices(config);
builder.Services.AddHttpClient();
var app = builder.Build();
await RoleSeed.SeedAsync(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.RegisterRoutes(config);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseHangfireDashboard();
app.UseRouting();
app.UseCors(x=>x.AllowAnyHeader()
    .AllowCredentials()
    .AllowAnyMethod()
    .SetIsOriginAllowed(t=>true)
    .SetPreflightMaxAge(TimeSpan.FromMinutes(10)));
app.UseAuthentication();
app.UseAuthorization();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
app.MapControllers();

app.UseHttpsRedirection();
app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<EaseDbContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    await context.Database.MigrateAsync();
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "error during migration");
};

app.Run();