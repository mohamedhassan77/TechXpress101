using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechXpress.Data;

namespace TechXpress.Models
{
    public class AuditLog :ISoftDelete
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [Required(ErrorMessage = "Action is required.")]
        public string Action { get; set; }

        [Required(ErrorMessage = "Details are required.")]
        public string Details { get; set; } // Add this property

        [Required(ErrorMessage = "Timestamp is required.")]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [Display(Name = "Is Deleted?")]
        public bool IsDeleted { get; set; }
    }
}