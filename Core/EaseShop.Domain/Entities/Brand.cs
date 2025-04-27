using EaseShop.Domain.Common;

namespace EaseShop.Domain.Entities;

public class Brand : BaseEntity
{
    public string Name { get; set; }
    public ICollection<SubCategoryBrand> SubCategoryBrands { get; set; }
}