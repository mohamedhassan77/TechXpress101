using Microsoft.AspNetCore.Mvc;
using TechXpress.Data;
using TechXpress.Models;
using System.Threading.Tasks;

namespace TechXpress.Controllers
{
    public class WishlistItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WishlistItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var wishlistItems = await _unitOfWork.WishlistItems.GetAllAsync(true);
            return View(wishlistItems);
        }

        public async Task<IActionResult> Details(int id)
        {
            var wishlistItem = await _unitOfWork.WishlistItems.GetByIdAsync(id);
            if (wishlistItem == null)
            {
                return NotFound();
            }
            return View(wishlistItem);
        }
    }
}