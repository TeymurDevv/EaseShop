using EaseShop.Domain.Entities;
using EaseShop.Domain.Repositories;
using EaseShop.Persistance.Data;

namespace EaseShop.Persistance.Implementations;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(EaseDbContext context) : base(context)
    {
    }
}