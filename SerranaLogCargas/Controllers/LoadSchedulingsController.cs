using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SerranaLogCargas.Data;
using SerranaLogCargas.Models;

namespace SerranaLogCargas.Controllers
{
    public class LoadSchedulingsController : Controller
    {
        private readonly SerranaLogCargasContext _context;

        public LoadSchedulingsController(SerranaLogCargasContext context)
        {
            _context = context;
        }

        // GET: LoadSchedulings
        public async Task<IActionResult> Index()
        {
            var serranaLogCargasContext = _context.LoadScheduling.Include(l => l.Customer);
            return View(await serranaLogCargasContext.ToListAsync());
        }

        // GET: LoadSchedulings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LoadScheduling == null)
            {
                return NotFound();
            }

            var loadScheduling = await _context.LoadScheduling
                .Include(l => l.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loadScheduling == null)
            {
                return NotFound();
            }

            return View(loadScheduling);
        }

        // GET: LoadSchedulings/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            return View();
        }

        // POST: LoadSchedulings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Bol,CustomerId,OriginId,DestinyId,UnloadDate,Weigth,VlTranspor,VlContract,Vladvance,Pay,ContractId,Cte")] LoadScheduling loadScheduling)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loadScheduling);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", loadScheduling.CustomerId);
            return View(loadScheduling);
        }

        // GET: LoadSchedulings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LoadScheduling == null)
            {
                return NotFound();
            }

            var loadScheduling = await _context.LoadScheduling.FindAsync(id);
            if (loadScheduling == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", loadScheduling.CustomerId);
            return View(loadScheduling);
        }

        // POST: LoadSchedulings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Bol,CustomerId,OriginId,DestinyId,UnloadDate,Weigth,VlTranspor,VlContract,Vladvance,Pay,ContractId,Cte")] LoadScheduling loadScheduling)
        {
            if (id != loadScheduling.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loadScheduling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoadSchedulingExists(loadScheduling.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", loadScheduling.CustomerId);
            return View(loadScheduling);
        }

        // GET: LoadSchedulings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LoadScheduling == null)
            {
                return NotFound();
            }

            var loadScheduling = await _context.LoadScheduling
                .Include(l => l.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loadScheduling == null)
            {
                return NotFound();
            }

            return View(loadScheduling);
        }

        // POST: LoadSchedulings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LoadScheduling == null)
            {
                return Problem("Entity set 'SerranaLogCargasContext.LoadScheduling'  is null.");
            }
            var loadScheduling = await _context.LoadScheduling.FindAsync(id);
            if (loadScheduling != null)
            {
                _context.LoadScheduling.Remove(loadScheduling);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoadSchedulingExists(int id)
        {
          return (_context.LoadScheduling?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
