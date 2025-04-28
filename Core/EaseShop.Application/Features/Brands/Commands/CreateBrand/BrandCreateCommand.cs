using EaseShop.Domain.Common.ResultPattern;
using MediatR;
using EaseShop.Domain.Entities;

namespace EaseShop.Application.Features.Brands.Commands.CreateBrand;

public record BrandCreateCommand(string name) : IRequest<Result<Unit>>
{
    public string Name { get; set; } = name;
}

public static class BrandCreateMappingExtensions
{
    public static Brand ToEntity(this BrandCreateCommand command)
    {
        return new Domain.Entities.Brand
        {
            Name = command.Name
        };
    }
}