using System.ComponentModel.DataAnnotations;

namespace OrderService.Domain;

public class OrderItem
{
    [Key]
    public Guid Id { get; set; }  // Unique order item identifier

    public Guid ProductId { get; set; }
    public ProductDto Product { get; set; }
    public int Quantity { get; set; }  // Quantity of the product in this order

    public decimal UnitPrice { get; set; }  // Price per unit

    public decimal TotalPrice { get; set; }  // Total price for this order item
}
