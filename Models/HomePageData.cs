using System.Collections.Generic;

namespace TechXpress.Models
{
    public class HomePageData
    {
        public List<Product> FeaturedProducts { get; set; } 
        public List<Category> PopularCategories { get; set; } 
        public List<Review> LatestReviews { get; set; } 
        public int TotalProducts { get; set; } 
        public int TotalOrders { get; set; } 
        public int TotalUsers { get; set; }
        public string WelcomeMessage { get; set; }
    }
}