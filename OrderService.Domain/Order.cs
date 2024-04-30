using System.ComponentModel.DataAnnotations;

namespace OrderService.Domain;

public class Order
{
    [Key]
    public Guid Id { get; set; }  // Unique order identifier

    public DateTime OrderDate { get; set; }  // Date when the order was placed

    public Guid UserId { get; set; }  // Foreign key to the customer who placed the order

    public virtual List<OrderItem> OrderItems { get; set; }  // Order items in this order

    public decimal TotalPrice { get; set; }  // Total price of the order

    public OrderStatus Status { get; set; }  // Current status of the order (e.g., Pending, Shipped, Completed)

}
