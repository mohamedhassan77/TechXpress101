using Microsoft.AspNetCore.Mvc;
using TechXpress.Data;
using TechXpress.Models;
using System.Threading.Tasks;

namespace TechXpress.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var payments = await _unitOfWork.Payments.GetAllAsync(true);
            return View(payments);
        }

        public async Task<IActionResult> Details(int id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }
    }
}