using LogCargas.Data;
using LogCargas.Models.ViewModels;
using LogCargas.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LogCargas.Controllers
{
    public class SettingsController : Controller
    {
        private readonly SeedingService _seedingService; 
        private readonly StateService _stateService;

        public SettingsController (SeedingService seedingService, StateService stateService)
        {
            _seedingService = seedingService;
            _stateService = stateService;
        }   

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StatePop()
        {
            _seedingService.Seed();
            return RedirectToAction(nameof(Index));
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
