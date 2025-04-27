using EaseShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EaseShop.Persistance.Configurations;

public class SubCategoryBrandConfiguration  : IEntityTypeConfiguration<SubCategoryBrand>
{
    public void Configure(EntityTypeBuilder<SubCategoryBrand> builder)
    {
        builder.HasKey(x => new { x.SubCategoryId, x.BrandId });
    }
}