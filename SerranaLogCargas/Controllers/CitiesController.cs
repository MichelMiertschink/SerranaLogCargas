using Microsoft.AspNetCore.Mvc;
using SerranaLogCargas.Models;
using SerranaLogCargas.Models.ViewModels;
using SerranaLogCargas.Services;
using System.Diagnostics;

namespace SerranaLogCargas.Controllers
{
    public class CitiesController : Controller
    {
        private readonly CityService _cityService;
        private readonly StateService _stateService;    
        public CitiesController(CityService cityService, StateService stateService)
        {
            _cityService = cityService;
            _stateService = stateService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _cityService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var states = await _stateService.FindAllAsync();
            var viewModel = new CityFormViewModel { States = states };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (City city)
        {
            if (ModelState.IsValid)
            {
                var states = await _stateService.FindAllAsync();
                var viewModel = new CityFormViewModel { States = states };
                return View(viewModel);
            }
            await _cityService.InsertAsync(city);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            var obj = await _cityService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" });
            }
            
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _cityService.Remove(id);
                return RedirectToAction(nameof(Index));
            } 
            catch (Exception e) 
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            var obj = await _cityService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            var obj = await _cityService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrada" });
            }
            List<State> states = await _stateService.FindAllAsync();
            CityFormViewModel viewModel = new CityFormViewModel { City = obj, States = states};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, City city)
        {
            if (!ModelState.IsValid)
            {
                var states = await _stateService.FindAllAsync();
                var viewModel = new CityFormViewModel { City = city, States = states };
                return View(viewModel);
            }
            if (id != city.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "IDs não correspondem" });
            }
            try
            {
                await _cityService.UpdateAsync(city);
                return RedirectToAction(nameof(Index));
            } 
            catch (ApplicationException ex) 
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });

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
