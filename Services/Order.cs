using TechXpress.Data;
using TechXpress.Models;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(int id);
    Task AddOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(int id);
}

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _unitOfWork.Orders.GetAllAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        return await _unitOfWork.Orders.GetByIdAsync(id);
    }

    public async Task AddOrderAsync(Order order)
    {
        await _unitOfWork.Orders.AddAsync(order);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateOrderAsync(Order order)
    {
        _unitOfWork.Orders.Update(order);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteOrderAsync(int id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        if (order != null)
        {
            _unitOfWork.Orders.Remove(order);
            await _unitOfWork.CompleteAsync();
        }
    }
}