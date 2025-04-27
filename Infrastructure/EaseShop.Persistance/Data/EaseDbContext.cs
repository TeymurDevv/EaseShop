using System.Reflection;
using EaseShop.Domain.Entities;
using EaseShop.Persistance.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EaseShop.Persistance.Data;

public class EaseDbContext : IdentityDbContext<AppUser>
{
    public EaseDbContext(DbContextOptions<EaseDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<SubCategoryBrand> SubCategoryBrands { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}