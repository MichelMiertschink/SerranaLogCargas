using Microsoft.AspNetCore.Mvc;
using SerranaLogCargas.Models;
using SerranaLogCargas.Services;

namespace SerranaLogCargas.Controllers
{
    public class StatesController : Controller
    {

        private readonly StateService _stateService;

        public StatesController(StateService stateService)
        {
            _stateService = stateService;
        }
        public IActionResult Index()
        {
            var list = _stateService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(State state) 
        {
            _stateService.Insert(state);
            return RedirectToAction(nameof(Index));
        }

    }
}
