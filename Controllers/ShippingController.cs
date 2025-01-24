using Microsoft.AspNetCore.Mvc;
using TechXpress.Data;
using TechXpress.Models;
using System.Threading.Tasks;

namespace TechXpress.Controllers
{
    public class ShippingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShippingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var shippings = await _unitOfWork.Shippings.GetAllAsync(true);
            return View(shippings);
        }

        public async Task<IActionResult> Details(int id)
        {
            var shipping = await _unitOfWork.Shippings.GetByIdAsync(id);
            if (shipping == null)
            {
                return NotFound();
            }
            return View(shipping);
        }
    }
}