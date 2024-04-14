using Microsoft.AspNetCore.Mvc;
using SerranaLogCargas.Models;
using SerranaLogCargas.Models.ViewModels;
using SerranaLogCargas.Services;

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
                return NotFound();
                //RedirectToAction(nameof(Error), new { message = "ID não encontrada" })
            }

            var obj = await _cityService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
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
                return NotFound();
                    // RedirectToAction(nameof(), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
                //RedirectToAction(nameof(Error), new { message = "ID não encontrada" })
            }

            var obj = await _cityService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
