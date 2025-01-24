using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechXpress.Data;

namespace TechXpress.Models
{
    public class Cart : ISoftDelete
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [Display(Name = "Is Deleted?")]
        public bool IsDeleted { get; set; }

        // Navigation properties
        public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
    }
}