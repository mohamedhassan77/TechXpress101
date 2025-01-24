using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechXpress.Data;

namespace TechXpress.Models
{
    public class Shipping : ISoftDelete
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Order ID is required.")]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [Required(ErrorMessage = "Shipping date is required.")]
        public DateTime ShippingDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
        public string Status { get; set; }

        [StringLength(100, ErrorMessage = "Tracking number cannot exceed 100 characters.")]
        public string TrackingNumber { get; set; }

        [Required(ErrorMessage = "Shipping method is required.")]
        [StringLength(100, ErrorMessage = "Shipping method cannot exceed 100 characters.")]
        public string ShippingMethod { get; set; } // Add this property

        [Display(Name = "Is Deleted?")]
        public bool IsDeleted { get; set; }
    }
}