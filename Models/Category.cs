using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechXpress.Data;

namespace TechXpress.Models
{
    public class Category : ISoftDelete
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Display(Name = "Is Deleted?")]
        public bool IsDeleted { get; set; }

        // Navigation properties
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}