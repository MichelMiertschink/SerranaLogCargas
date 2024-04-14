using Microsoft.AspNetCore.Mvc;
using SerranaLogCargas.Models;
using SerranaLogCargas.Services;
using System.Net.WebSockets;

namespace SerranaLogCargas.Controllers
{
    public class CitiesController : Controller
    {
        private readonly CityService _cityService;
        public CitiesController(CityService cityService)
        {
            _cityService = cityService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _cityService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (City city)
        {
            if (ModelState.IsValid)
            {
                
            }
            await _cityService.InsertAsync(city);
            return RedirectToAction(nameof(Index));
        }
    }
}
