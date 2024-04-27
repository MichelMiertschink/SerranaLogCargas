using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SerranaLogCargas.Models;
using SerranaLogCargas.Models.ViewModels;
using SerranaLogCargas.Services;

namespace SerranaLogCargas.Controllers
{
    public class LoadSchedulingController : Controller
    {
        private readonly LoadSchedulingService _loadSchedulingService;
        private readonly CustomerService _customerService;
        private readonly CityService _cityService;

        public LoadSchedulingController (LoadSchedulingService loadScheduling, CustomerService customerService, CityService cityService)
        {
            _loadSchedulingService = loadScheduling;
            _customerService = customerService;
            _cityService = cityService;
        }
    
        public async Task<IActionResult> Index()
        {
            var list = await _loadSchedulingService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
                var customers = await _customerService.FindAllAsync();
                var cities = await _cityService.FindAllAsync();
                var viewModel = new LoadSchedulingFormViewModel { Customer = customers, City = cities };
                return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (LoadScheduling loadScheduling)
        {
            if (ModelState.IsValid)
            {
                var customers = await _customerService.FindAllAsync();
                var cities = await _cityService.FindAllAsync();
                var viewModel = new LoadSchedulingFormViewModel { Customer = customers, City = cities };
                return View(viewModel);
            }
            await _loadSchedulingService.InsertAsync(loadScheduling);
            return RedirectToAction(nameof(Index));
        }

    }
}
