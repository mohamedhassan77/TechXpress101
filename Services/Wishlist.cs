using TechXpress.Data;
using TechXpress.Models;

public interface IWishlistService
{
    Task<IEnumerable<Wishlist>> GetAllWishlistsAsync();
    Task<Wishlist> GetWishlistByIdAsync(int id);
    Task AddWishlistAsync(Wishlist wishlist);
    Task UpdateWishlistAsync(Wishlist wishlist);
    Task DeleteWishlistAsync(int id);
}

public class WishlistService : IWishlistService
{
    private readonly IUnitOfWork _unitOfWork;

    public WishlistService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Wishlist>> GetAllWishlistsAsync()
    {
        return await _unitOfWork.Wishlists.GetAllAsync();
    }

    public async Task<Wishlist> GetWishlistByIdAsync(int id)
    {
        return await _unitOfWork.Wishlists.GetByIdAsync(id);
    }

    public async Task AddWishlistAsync(Wishlist wishlist)
    {
        await _unitOfWork.Wishlists.AddAsync(wishlist);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateWishlistAsync(Wishlist wishlist)
    {
        _unitOfWork.Wishlists.Update(wishlist);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteWishlistAsync(int id)
    {
        var wishlist = await _unitOfWork.Wishlists.GetByIdAsync(id);
        if (wishlist != null)
        {
            _unitOfWork.Wishlists.Remove(wishlist);
            await _unitOfWork.CompleteAsync();
        }
    }
}