using EaseShop.Domain.Common;

namespace EaseShop.Domain.Entities;

public class Category : BaseEntity
{
    public required string Name { get; set; }
}