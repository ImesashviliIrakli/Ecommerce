namespace OrderService.Application.Models;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public CategoryDto Category { get; set; }
    public int StockQuantity { get; set; }
}
