using System.ComponentModel.DataAnnotations;

namespace ProductService.Domain;

public class Category
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
