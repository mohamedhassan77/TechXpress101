using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechXpress.Data;

namespace TechXpress.Models
{
    public class Order : ISoftDelete
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [Required(ErrorMessage = "Order date is required.")]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Is Deleted?")]
        public bool IsDeleted { get; set; }

        // Navigation properties
        public ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
        public ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
        public ICollection<Shipping> Shippings { get; set; } = new HashSet<Shipping>();
    }
}