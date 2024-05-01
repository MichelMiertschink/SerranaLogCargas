using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SerranaLogCargas.Models;
using SerranaLogCargas.Models.ViewModels;
using SerranaLogCargas.Services;
using System.Diagnostics;

namespace SerranaLogCargas.Controllers
{
    public class LoadSchedulingController : Controller
    {
        private readonly LoadSchedulingService _loadSchedulingService;
        private readonly CustomerService _customerService;
        private readonly CityService _cityService;

        public LoadSchedulingController(LoadSchedulingService loadScheduling, CustomerService customerService, CityService cityService)
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
            try
            {
                var customers = await _customerService.FindAllAsync();
                var cities = await _cityService.FindAllAsync();
                var viewModel = new LoadSchedulingFormViewModel { Customer = customers, City = cities };
                return View(viewModel);
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoadScheduling loadScheduling)
        {
            if (ModelState.IsValid)
            {
                var customers = await _customerService.FindAllAsync();
                var cities = await _cityService.FindAllAsync();
                var viewModel = new LoadSchedulingFormViewModel { Customer = customers, City = cities };
                return View(viewModel);
            }

            try
            {
                await _loadSchedulingService.InsertAsync(loadScheduling);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                return RedirectToAction(nameof(Error), new
                {
                    message = e.Message +
                    "CustomerID: " + loadScheduling.CustomerId.ToString() +
                    "\nOriginID: " + loadScheduling.CityDestinyId.ToString() +
                    "\nDestinyID: " + loadScheduling.CityOriginId.ToString()
                });
            }

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { mnessage = "Id não fornecido" });
            }
            var loadSchedule = _loadSchedulingService.FindByIdAsync(id.Value);
            if (loadSchedule == null)
            {
                return RedirectToAction(nameof(Error), new { mnessage = "Id não encontrado" });
            }
            return View(loadSchedule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete (int id)
        {
            try
            {
                await _loadSchedulingService.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { mnessage = "Id não fornecido" });
            }
            var loadSchedule = _loadSchedulingService.FindByIdAsync(id.Value);
            if (loadSchedule == null)
            {
                return RedirectToAction(nameof(Error), new { mnessage = "Id não encontrado" });
            }
            return View(loadSchedule);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { mnessage = "Id não fornecido" });
            }
            var loadSchedule = _loadSchedulingService.FindByIdAsync(id.Value);
            if (loadSchedule == null)
            {
                return RedirectToAction(nameof(Error), new { mnessage = "Id não encontrado" });
            }
            List<Customer> customers = await _customerService.FindAllAsync();
            List<City> cities = await _cityService.FindAllAsync();
            var viewModel = new LoadSchedulingFormViewModel { Customer = customers, City = cities };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, LoadScheduling loadScheduling)
        {
            if (ModelState.IsValid)
            {
                var customers = await _customerService.FindAllAsync();
                var cities = await _cityService.FindAllAsync();
                var viewModel = new LoadSchedulingFormViewModel { Customer = customers, City = cities };
                return View(viewModel);
            }
            if (id != loadScheduling.Id) 
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            try
            {
                await _loadSchedulingService.UpdateAsync(loadScheduling);
                return RedirectToAction(nameof(Index));
            } catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }


        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

    }
}
