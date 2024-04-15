using Microsoft.AspNetCore.Mvc;
using SerranaLogCargas.Data;
using SerranaLogCargas.Services;

namespace SerranaLogCargas.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerService _customerService;
        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task <IActionResult> Index()
        {
            var list = await _customerService.FindAllAsync();
            return View(list);
        }
    }
}
