using OrderService.Domain;

namespace OrderService.Application.Contracts;

public interface IOrderItemRepository
{
    // Add an order item
    Task<OrderItem> Add(OrderItem orderItem);

    // Get all order items for a specific order
    Task<List<OrderItem>> GetByOrderId(Guid orderId);

    // Get an order item by ID
    Task<OrderItem> GetById(Guid orderItemId);

    // Update an existing order item
    Task<OrderItem> Update(OrderItem orderItem);

    // Delete an order item by ID
    Task<bool> Delete(Guid orderItemId);
}
