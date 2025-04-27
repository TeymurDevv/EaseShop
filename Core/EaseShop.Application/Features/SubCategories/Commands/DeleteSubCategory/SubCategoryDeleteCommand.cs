using EaseShop.Domain.Common.ResultPattern;
using MediatR;

namespace EaseShop.Application.Features.SubCategories.Commands.DeleteSubCategory;

public record SubCategoryDeleteCommand(int id) : IRequest<Result<Unit>>
{
    public int Id { get; set; } = id;
}