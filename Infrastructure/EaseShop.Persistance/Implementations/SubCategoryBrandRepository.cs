using EaseShop.Domain.Entities;
using EaseShop.Domain.Repositories;
using EaseShop.Persistance.Data;

namespace EaseShop.Persistance.Implementations;

public class SubCategoryBrandRepository  : Repository<SubCategoryBrand>, ISubCategoryBrandRepository
{
    public SubCategoryBrandRepository(EaseDbContext context) : base(context)
    {
    }
}