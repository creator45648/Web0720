using Microsoft.AspNetCore.Mvc;

namespace Web.View.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public IActionResult Index()
        {
            return View();
        }
    }
}