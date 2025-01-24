using Microsoft.AspNetCore.Mvc;
using TechXpress.Data;
using TechXpress.Models;
using System.Threading.Tasks;

namespace TechXpress.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WishlistController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var wishlists = await _unitOfWork.Wishlists.GetAllAsync(true);
            return View(wishlists);
        }

        public async Task<IActionResult> Details(int id)
        {
            var wishlist = await _unitOfWork.Wishlists.GetByIdAsync(id);
            if (wishlist == null)
            {
                return NotFound();
            }
            return View(wishlist);
        }
    }
}