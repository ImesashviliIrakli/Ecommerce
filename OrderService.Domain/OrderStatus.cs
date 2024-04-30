namespace OrderService.Domain;

public enum OrderStatus
{
    Pending,   // Order placed but not yet processed
    Processing,  // Order is being processed
    Shipped,  // Order has been shipped
    Completed,  // Order completed and delivered
    Cancelled  // Order has been cancelled
}