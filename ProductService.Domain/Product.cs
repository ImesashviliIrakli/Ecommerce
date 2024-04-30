using System.ComponentModel.DataAnnotations;

namespace ProductService.Domain;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public int StockQuantity { get; set; }
}
