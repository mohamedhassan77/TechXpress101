using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechXpress.Data;

namespace TechXpress.Models
{
    [Table("Addresses")]
    public class Address : ISoftDelete
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(100, ErrorMessage = "Full Name cannot exceed 100 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Address Line 1 is required.")]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; } 

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; } 

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zip Code is required.")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; } 

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; } 

        [Display(Name = "Is Default?")]
        public bool IsDefault { get; set; } 

        [Display(Name = "Is Deleted?")]
        public bool IsDeleted { get; set; }
    }
}