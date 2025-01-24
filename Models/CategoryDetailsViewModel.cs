using System.Collections.Generic;

namespace TechXpress.Models
{
    public class CategoryDetailsViewModel
    {
        public Category Category { get; set; }
        public List<Product> Products { get; set; }
    }
}