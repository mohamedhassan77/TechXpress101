using Microsoft.AspNetCore.Mvc;
using TechXpress.Data;
using TechXpress.Models;
using System.Threading.Tasks;

namespace TechXpress.Controllers
{
    public class CartItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var cartItems = await _unitOfWork.CartItems.GetAllAsync(true);
            return View(cartItems);
        }

        public async Task<IActionResult> Details(int id)
        {
            var cartItem = await _unitOfWork.CartItems.GetByIdAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            return View(cartItem);
        }
    }
}