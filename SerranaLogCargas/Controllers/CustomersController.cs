using Microsoft.AspNetCore.Mvc;
using SerranaLogCargas.Data;
using SerranaLogCargas.Models;
using SerranaLogCargas.Models.ViewModels;
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

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (Customer customer)
        {
            if (ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel { };
                return View(viewModel);
            }
            await _customerService.InsertAsync(customer);
            return RedirectToAction(nameof(Index));
        }

    }
}
