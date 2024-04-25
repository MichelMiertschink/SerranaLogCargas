using Microsoft.AspNetCore.Mvc;
using SerranaLogCargas.Services;

namespace SerranaLogCargas.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly VehicleService _vehicleService;

        public VehiclesController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _vehicleService.FindAllAsync();
            return View(list);
        }
    }
}
