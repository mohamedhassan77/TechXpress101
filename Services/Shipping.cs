using TechXpress.Data;
using TechXpress.Models;

public interface IShippingService
{
    Task<IEnumerable<Shipping>> GetAllShippingsAsync();
    Task<Shipping> GetShippingByIdAsync(int id);
    Task AddShippingAsync(Shipping shipping);
    Task UpdateShippingAsync(Shipping shipping);
    Task DeleteShippingAsync(int id);
}

public class ShippingService : IShippingService
{
    private readonly IUnitOfWork _unitOfWork;

    public ShippingService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Shipping>> GetAllShippingsAsync()
    {
        return await _unitOfWork.Shippings.GetAllAsync();
    }

    public async Task<Shipping> GetShippingByIdAsync(int id)
    {
        return await _unitOfWork.Shippings.GetByIdAsync(id);
    }

    public async Task AddShippingAsync(Shipping shipping)
    {
        await _unitOfWork.Shippings.AddAsync(shipping);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateShippingAsync(Shipping shipping)
    {
        _unitOfWork.Shippings.Update(shipping);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteShippingAsync(int id)
    {
        var shipping = await _unitOfWork.Shippings.GetByIdAsync(id);
        if (shipping != null)
        {
            _unitOfWork.Shippings.Remove(shipping);
            await _unitOfWork.CompleteAsync();
        }
    }
}