using Microsoft.AspNetCore.Mvc;
using TechXpress.Models;

namespace TechXpress.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var errorViewModel = new ErrorViewModel
            {
                StatusCode = statusCode,
                ErrorMessage = statusCode switch
                {
                    404 => "The page you are looking for does not exist.",
                    500 => "An internal server error occurred.",
                    _ => "An unexpected error occurred."
                }
            };

            return View("Error", errorViewModel);

        }
    }
}