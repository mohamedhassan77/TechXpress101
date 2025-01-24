using Microsoft.EntityFrameworkCore;
using TechXpress.Models;

namespace TechXpress.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechXpressContext _context;

        public UnitOfWork(TechXpressContext context)
        {
            _context = context;
            Products = new Repository<Product>(_context);
            Categories = new Repository<Category>(_context);
            Orders = new Repository<Order>(_context);
            OrderDetails = new Repository<OrderDetail>(_context);
            Reviews = new Repository<Review>(_context);
            Addresses = new Repository<Address>(_context);
            AuditLogs = new Repository<AuditLog>(_context);
            Carts = new Repository<Cart>(_context);
            CartItems = new Repository<CartItem>(_context);
            Wishlists = new Repository<Wishlist>(_context);
            WishlistItems = new Repository<WishlistItem>(_context);
            Payments = new Repository<Payment>(_context);
            Shippings = new Repository<Shipping>(_context);
            UserProfiles = new Repository<UserProfile>(_context);
        }

        public IRepository<Product> Products { get; }
        public IRepository<Category> Categories { get; }
        public IRepository<Order> Orders { get; }
        public IRepository<OrderDetail> OrderDetails { get; }
        public IRepository<Review> Reviews { get; }
        public IRepository<Address> Addresses { get; }
        public IRepository<AuditLog> AuditLogs { get; }
        public IRepository<Cart> Carts { get; }
        public IRepository<CartItem> CartItems { get; }
        public IRepository<Wishlist> Wishlists { get; }
        public IRepository<WishlistItem> WishlistItems { get; }
        public IRepository<Payment> Payments { get; }
        public IRepository<Shipping> Shippings { get; }
        public IRepository<UserProfile> UserProfiles { get; }
        public void Rollback()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                entry.State = EntityState.Detached;
            }
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync(); // Save changes to the database
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}