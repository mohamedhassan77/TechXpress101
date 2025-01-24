using Microsoft.AspNetCore.Mvc;
using TechXpress.Data;
using TechXpress.Models;
using System.Threading.Tasks;

namespace TechXpress.Controllers
{
    public class AuditLogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuditLogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await _unitOfWork.AuditLogs.GetAllAsync(true);
            return View(logs);
        }

        public async Task<IActionResult> Details(int id)
        {
            var log = await _unitOfWork.AuditLogs.GetByIdAsync(id);
            if (log == null)
            {
                return NotFound();
            }
            return View(log);
        }
    }
}