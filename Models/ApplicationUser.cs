using Microsoft.AspNetCore.Identity;
using TechXpress.Models;

public class ApplicationUser : IdentityUser
{
    // Navigation properties
    public ICollection<Order> Orders { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<Cart> Carts { get; set; }
    public ICollection<Wishlist> Wishlists { get; set; }
    public ICollection<Payment> Payments { get; set; }
    public ICollection<Shipping> Shippings { get; set; }
    public ICollection<AuditLog> AuditLogs { get; set; }
    public UserProfile UserProfile { get; set; }
}