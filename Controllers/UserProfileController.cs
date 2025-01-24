using Microsoft.AspNetCore.Mvc;
using TechXpress.Data;
using TechXpress.Models;
using System.Threading.Tasks;

namespace TechXpress.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserProfileController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var userProfiles = await _unitOfWork.UserProfiles.GetAllAsync(true);
            return View(userProfiles);
        }

        public async Task<IActionResult> Details(int id)
        {
            var userProfile = await _unitOfWork.UserProfiles.GetByIdAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            return View(userProfile);
        }
    }
}