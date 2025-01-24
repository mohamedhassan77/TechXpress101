using TechXpress.Data;
using TechXpress.Models;

public interface ICartService
{
    Task<IEnumerable<Cart>> GetAllCartsAsync();
    Task<Cart> GetCartByIdAsync(int id);
    Task AddCartAsync(Cart cart);
    Task UpdateCartAsync(Cart cart);
    Task DeleteCartAsync(int id);
}

public class CartService : ICartService
{
    private readonly IUnitOfWork _unitOfWork;

    public CartService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Cart>> GetAllCartsAsync()
    {
        return await _unitOfWork.Carts.GetAllAsync();
    }

    public async Task<Cart> GetCartByIdAsync(int id)
    {
        return await _unitOfWork.Carts.GetByIdAsync(id);
    }

    public async Task AddCartAsync(Cart cart)
    {
        await _unitOfWork.Carts.AddAsync(cart);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateCartAsync(Cart cart)
    {
        _unitOfWork.Carts.Update(cart);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteCartAsync(int id)
    {
        var cart = await _unitOfWork.Carts.GetByIdAsync(id);
        if (cart != null)
        {
            _unitOfWork.Carts.Remove(cart);
            await _unitOfWork.CompleteAsync();
        }
    }
}