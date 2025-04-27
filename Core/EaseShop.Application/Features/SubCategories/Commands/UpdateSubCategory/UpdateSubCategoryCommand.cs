using EaseShop.Domain.Common.ResultPattern;
using MediatR;

namespace EaseShop.Application.Features.SubCategories.Commands.UpdateSubCategory;

public class UpdateSubCategoryCommand(int id, int categoryId, string name) : IRequest<Result<Unit>>
{
    public int Id { get; set; } = id;
    public int CategoryId { get; set; } = categoryId;
    public string Name { get; set; } = name;
}