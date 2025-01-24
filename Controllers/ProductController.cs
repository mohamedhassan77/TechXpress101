using Microsoft.AspNetCore.Mvc;
using TechXpress.Data;
using TechXpress.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechXpress.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Product/Index
        public async Task<IActionResult> Index()
        {
            // Fetch all products with their categories
            var products = await _unitOfWork.Products.GetAllAsync(true);
            return View(products);
        }

        // GET: Product/Create
        public async Task<IActionResult> Create()
        {
            // Fetch all categories for the dropdown
            var categories = await _unitOfWork.Categories.GetAllAsync(true);
            ViewBag.Category = new SelectList(categories, "Id", "Name");

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

         public async Task<IActionResult> Create(Product product)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(true);
            ViewBag.Category = new SelectList(categories, "Id", "Name");
           
            if (ModelState.IsValid)
            {

                await _unitOfWork.Products.AddAsync(product);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }


        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            // Fetch the product by ID
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            // Fetch all categories for the dropdown
            var categories = await _unitOfWork.Categories.GetAllAsync();
            ViewBag.Category = new SelectList(categories, "Id", "Name");

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Update the product in the database
                _unitOfWork.Products.Update(product);
                await _unitOfWork.CompleteAsync();

                return RedirectToAction(nameof(Index));
            }

            // If the model state is invalid, repopulate the categories dropdown
            var categories = await _unitOfWork.Categories.GetAllAsync();
            ViewBag.Category = new SelectList(categories, "Id", "Name");

            return View(product);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int id)
        {
            // Fetch the product by ID, including its category
            var product = await _unitOfWork.Products.GetByIdWithCategoryAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Delete/5
       

        public async Task<IActionResult> Delete(int id) 
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product != null)
            {
                
                _unitOfWork.Products.Remove(product);
                await _unitOfWork.CompleteAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}