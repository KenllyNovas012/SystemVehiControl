using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemVehiControl.ApplicationContext;
using SystemVehiControl.Models;

namespace SystemVehiControl.Controllers
{
    public class EngineController : Controller
    {
        private readonly VehixControlContext _context;

        public EngineController(VehixControlContext context)
        {
            _context = context;
        }

        // GET: Engine
        public async Task<IActionResult> Index()
        {
            return View(await _context.Engines.ToListAsync());
        }

        // GET: Engine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var engine = await _context.Engines
                .FirstOrDefaultAsync(m => m.Id == id);

            if (engine == null) return NotFound();

            return View(engine);
        }

        // GET: Engine/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Engine/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Engine engine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(engine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(engine);
        }

        // GET: Engine/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var engine = await _context.Engines.FindAsync(id);
            if (engine == null) return NotFound();

            return View(engine);
        }

        // POST: Engine/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Engine engine)
        {
            if (id != engine.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(engine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EngineExists(engine.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(engine);
        }

        // GET: Engine/Delete/5

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var Engines = await _context.Engines.FindAsync(id);
            if (Engines == null)
            {
                return NotFound();
            }

            _context.Engines.Remove(Engines);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool EngineExists(int id)
        {
            return _context.Engines.Any(e => e.Id == id);
        }
    }
}
