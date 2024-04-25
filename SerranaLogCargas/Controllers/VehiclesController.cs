using Microsoft.AspNetCore.Mvc;
using SerranaLogCargas.Models;
using SerranaLogCargas.Models.ViewModels;
using SerranaLogCargas.Services;
using System.Diagnostics;

namespace SerranaLogCargas.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly VehicleService _vehicleService;
        private readonly DriverService _driverService;

        public VehiclesController(VehicleService vehicleService, DriverService driverService)
        {
            _vehicleService = vehicleService;
            _driverService = driverService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _vehicleService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var drivers = await _driverService.FindAllAsync();
            var viewModel = new VehicleFormViewModel { Driver = drivers };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                var drivers = await _driverService.FindAllAsync();
                var viewModel = new VehicleFormViewModel { Driver = drivers };
                return View(viewModel);
            }
            await _vehicleService.InsertAsync(vehicle);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecida" });
            }

            var obj = await _vehicleService.FindByIdAsync(id.Value);
            if (obj == null) 
            {
                return RedirectToAction(nameof(Error), new {message = "ID não encontrado"});
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _vehicleService.Remove(id);
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
                return RedirectToAction(nameof(Error), new { message = "ID não fornecida" });
            }

            var obj = await _vehicleService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" });
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecida" });
            }

            var obj = await _vehicleService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" });
            }
            List<Driver> drivers = await _driverService.FindAllAsync();
            VehicleFormViewModel viewModel = new VehicleFormViewModel { Vehicle = obj, Driver = drivers };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                var drivers = await _driverService.FindAllAsync();
                var viewModel = new VehicleFormViewModel { Vehicle = vehicle, Driver = drivers };
                return View(viewModel);
            }
            if (id != vehicle.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }
            try
            {
                await _vehicleService.UpdateAsync(vehicle);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
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
