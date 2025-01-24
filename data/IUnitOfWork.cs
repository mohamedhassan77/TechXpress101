using TechXpress.Models;

namespace TechXpress.Data
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderDetail> OrderDetails { get; }
        IRepository<Review> Reviews { get; }
        IRepository<Address> Addresses { get; }
        IRepository<AuditLog> AuditLogs { get; }
        IRepository<Cart> Carts { get; }
        IRepository<CartItem> CartItems { get; }
        IRepository<Wishlist> Wishlists { get; }
        IRepository<WishlistItem> WishlistItems { get; }
        IRepository<Payment> Payments { get; }
        IRepository<Shipping> Shippings { get; }
        IRepository<UserProfile> UserProfiles { get; }

        Task CompleteAsync(); 
        Task SaveAsync();
    }
}