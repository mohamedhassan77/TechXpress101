using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TechXpress.Data;
using TechXpress.Models;

namespace TechXpress.Controllers
{
    public class HomeController : Controller
    {
        private readonly TechXpressContext _context;
        private readonly ILogger<HomeController> _logger;

        // Added ILogger for error logging
        public HomeController(TechXpressContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Converted to async method
        public async Task<IActionResult> Index()
        {
            try
            {
                // Using async methods for database operations
                var homePageData = new HomePageData
                {
                    FeaturedProducts = await _context.Products
                        .Take(5)
                        .ToListAsync(),

                    PopularCategories = await _context.Categories
                        .Take(6)
                        .ToListAsync(),

                    LatestReviews = await _context.Reviews
                        .OrderByDescending(r => r.CreatedDate)
                        .Take(5)
                        .ToListAsync(),

                    // Using async Count operations
                    TotalProducts = await _context.Products.CountAsync(),
                    TotalOrders = await _context.Orders.CountAsync(),
                    TotalUsers = await _context.Users.CountAsync()
                };

                return View(homePageData);
            }
            catch (Exception ex)
            {
                // Log the error and return error view
                _logger.LogError(ex, "An error occurred while loading the home page");
                return View("Error");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}