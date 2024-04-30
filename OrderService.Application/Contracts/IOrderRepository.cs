using OrderService.Domain;

namespace OrderService.Application.Contracts;

public interface IOrderRepository
{
    // Create a new order
    Task<Order> Add(Order order);

    // Get all orders
    Task<List<Order>> GetAll();

    // Get an order by ID
    Task<Order> GetById(Guid orderId);

    // Get orders by customer ID
    Task<List<Order>> GetByCustomerId(Guid customerId);

    // Get orders by status
    Task<List<Order>> GetByStatus(OrderStatus status);

    // Update an existing order
    Task<Order> Update(Order order);

    // Delete an order by ID
    Task<bool> Delete(Guid orderId);
}
