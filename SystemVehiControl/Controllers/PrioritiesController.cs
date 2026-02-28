using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemVehiControl.ApplicationContext;
using SystemVehiControl.Models;

namespace SystemVehiControl.Controllers
{
    public class PrioritiesController : Controller
    {
        private readonly VehixControlContext _context;

        public PrioritiesController(VehixControlContext context)
        {
            _context = context;
        }
        // GET: Priorities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Priorities.ToListAsync());
        }

        // GET: Priorities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var priority = await _context.Priorities
                .FirstOrDefaultAsync(m => m.PriorityId == id);
            if (priority == null) return NotFound();

            return View(priority);
        }

        // GET: Priorities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Priorities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Priority priority)
        {
            try
            {
                _context.Add(priority);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Puedes loguear el error si tienes logging
                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar el vehículo. Intente de nuevo.");
            }
            return View(priority);
        }

        // GET: Priorities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var priority = await _context.Priorities.FindAsync(id);
            if (priority == null) return NotFound();

            return View(priority);
        }

        // POST: Priorities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Priority priority)
        {
            if (id != priority.PriorityId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(priority);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriorityExists(priority.PriorityId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(priority);
        }

        // GET: Priorities/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var Priorities = await _context.Priorities.FindAsync(id);
            if (Priorities == null)
            {
                return NotFound();
            }

            _context.Priorities.Remove(Priorities);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        private bool PriorityExists(int id)
        {
            return _context.Priorities.Any(e => e.PriorityId == id);
        }
    }
}
