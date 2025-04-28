using EaseShop.Domain.Entities;
using EaseShop.Domain.Repositories;
using EaseShop.Persistance.Data;

namespace EaseShop.Persistance.Implementations;

public class BrandRepository : Repository<Brand>, IBrandRepository
{
    public BrandRepository(EaseDbContext context) : base(context)
    {
    }
}