using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechXpress.Data;

namespace TechXpress.Models
{
    [Table("Products")]
    public class Product : ISoftDelete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Product Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0, 1000000, ErrorMessage = "Price must be between 0 and 1000,000.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Product Price")]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required.")]

        [Range(1, int.MaxValue, ErrorMessage = "Category is required.")]

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Display(Name = "Is Deleted?")]
        public bool IsDeleted { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        // Navigation properties
        public ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
        public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
        public ICollection<WishlistItem> WishlistItems { get; set; } = new HashSet<WishlistItem>();
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    }
}