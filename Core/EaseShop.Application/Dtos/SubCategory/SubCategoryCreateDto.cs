namespace EaseShop.Application.Dtos.SubCategory;

public record SubCategoryCreateDto
{
    public int CategoryId { get; set; }
    public string? Name { get; set; }
}