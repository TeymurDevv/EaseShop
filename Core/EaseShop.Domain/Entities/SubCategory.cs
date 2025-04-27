using EaseShop.Domain.Common;

namespace EaseShop.Domain.Entities;

public class SubCategory : BaseEntity
{
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public string Name { get; set; }
}