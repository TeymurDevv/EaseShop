using EaseShop.Domain.Common;

namespace EaseShop.Domain.Entities;

public class SubCategoryBrand : BaseEntity
{
    public int SubCategoryId { get; set; }
    public SubCategory SubCategory { get; set; }

    public int BrandId { get; set; }
    public Brand Brand { get; set; }
}