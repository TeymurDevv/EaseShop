using EaseShop.Domain.Entities;
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
}