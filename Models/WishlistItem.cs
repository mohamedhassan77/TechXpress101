using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechXpress.Models
{
    public class WishlistItem 
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wishlist ID is required.")]
        public int WishlistId { get; set; }

        [ForeignKey("WishlistId")]
        public Wishlist Wishlist { get; set; }

        [Required(ErrorMessage = "Product ID is required.")]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    }
}