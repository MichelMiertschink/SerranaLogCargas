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

        public IActionResult Delete (int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _stateService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (int? id)
        {

        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _stateService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

    }
}
