using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.API.Client;

namespace Web.View.Pages.Customers
{
    public class CustomersController : Controller
    {
        private readonly View.IWebApiClient<string, Customer> webApiClient;

        public CustomersController(IWebApiClient<string, Customer> webApiClient)
        {
            this.webApiClient = webApiClient;
        }
        // GET: CustomersController
        public ActionResult Index()
        {
            return View();
        }
    }
}
