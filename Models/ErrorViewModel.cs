namespace TechXpress.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; } 
        public string ErrorMessage { get; set; } 
        public int StatusCode { get; set; } // HTTP status code (e.g., 404, 500)
        public string StackTrace { get; set; } // Stack trace for debugging (optional)

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); 
    }
}