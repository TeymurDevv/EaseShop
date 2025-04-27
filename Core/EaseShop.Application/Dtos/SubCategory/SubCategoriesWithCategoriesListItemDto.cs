using EaseShop.Application.Dtos.Category;

namespace EaseShop.Application.Dtos.SubCategory;

public class SubCategoriesWithCategoriesListItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public CategoryReturnDto Category { get; set; }
}