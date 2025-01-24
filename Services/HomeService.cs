using System.Threading.Tasks;
using TechXpress.Models;

namespace TechXpress.Services
{
    public class HomeService : IHomeService
    {
        public async Task<HomePageData> GetHomePageDataAsync()
        {
            // Simulate fetching data from a database or external API
            var data = new HomePageData
            {
                WelcomeMessage = "Welcome to TechXpress!",
                FeaturedProducts = new List<Product>()
            };

            await Task.Delay(100); // Simulate async operation
            return data;
        }
    }
}