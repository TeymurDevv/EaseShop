namespace EaseShop.Domain.Common;

public class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.CreateVersion7();
    }
    public Guid Id { get; set; }
}