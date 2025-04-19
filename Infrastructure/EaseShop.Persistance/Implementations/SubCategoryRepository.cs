using EaseShop.Domain.Entities;
using EaseShop.Domain.Repositories;
using EaseShop.Persistance.Data;

namespace EaseShop.Persistance.Implementations;

public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
{
    public SubCategoryRepository(EaseDbContext context) : base(context)
    {
    }
}