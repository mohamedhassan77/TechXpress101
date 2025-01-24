using Microsoft.AspNetCore.Mvc;
using TechXpress.Data;
using TechXpress.Models;
using System.Threading.Tasks;

namespace TechXpress.Controllers
{
    public class AddressController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var addresses = await _unitOfWork.Addresses.GetAllAsync(true);
            return View(addresses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Address address)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Addresses.AddAsync(address);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var address = await _unitOfWork.Addresses.GetByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Addresses.Update(address);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(address);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var address = await _unitOfWork.Addresses.GetByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _unitOfWork.Addresses.GetByIdAsync(id);
            if (address != null)
            {
                _unitOfWork.Addresses.Remove(address);
                await _unitOfWork.CompleteAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}