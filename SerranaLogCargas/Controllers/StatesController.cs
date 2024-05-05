using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LogCargas.Models;
using LogCargas.Models.ViewModels;
using LogCargas.Services;

namespace LogCargas.Controllers
{
    public class StatesController : Controller
    {
        private readonly StateService _stateService;

        public StatesController(StateService stateService)
        {
            _stateService = stateService;
        }

        // GET: States
        public async Task<IActionResult> Index()
        {
            var list = await _stateService.FindAllAsync();
            return View(list);
        }

        // GET: States/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: States/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(State state)
        {
            await _stateService.InsertAsync(state);
            return RedirectToAction(nameof(Index));
        }

        // GET: States/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecida" });
            }

            var state = await _stateService.FindByIdAsync(id.Value);
            if (state == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrada" });
            }

            return View(state);
        }

        // POST: States/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _stateService.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error), new { message = "Existe cidade cadastrada para o estado. " +
                    "\nNão é possível excluir."
                });
            }
        }

        // GET: States/Details/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecida" });
            }

            var state = await _stateService.FindByIdAsync(id.Value);
            if (state == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrada" });
            }
            return View(state);
        }
        
        // GET: States/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecida" });
            }

            var state = await _stateService.FindByIdAsync(id.Value);
            if (state == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrada" });
            }
            return View(state);
        }

        // POST: States/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, State state)
        {
           if (ModelState.IsValid)
            {
                var viewModel = new StateFormViewModel { };
                return View(viewModel);
            }
           if (id != state.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
           try
            {
                await _stateService.UpdateAsync(state);
                return RedirectToAction(nameof(Index));
            }catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
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
