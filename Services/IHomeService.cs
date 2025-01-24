using System.Threading.Tasks;
using TechXpress.Models;

namespace TechXpress.Services
{
    public interface IHomeService
    {
        Task<HomePageData> GetHomePageDataAsync();
    }
}