using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SystemVehiControl.ApplicationContext;
using SystemVehiControl.Models;

namespace SystemVehiControl.Controllers
{
    public class ArticleController : Controller
    {
        private readonly VehixControlContext _context;

        public ArticleController(VehixControlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var vehicles = _context.Articles.Include(v => v.Category);

            return View(await vehicles.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var vehicle = await _context.Articles
                .Include(v => v.Category)
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (vehicle == null) return NotFound();

            return View(vehicle);
        }

        // GET: Vehicles/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryId", "Name");
                       
            return View();
        }

        // POST: Vehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Article  article)
        {
            try
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Puedes loguear el error si tienes logging
                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar el vehículo. Intente de nuevo.");
            }
            ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryId", "Name");
            return View(article);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var Article = await _context.Articles.FindAsync(id);
            if (Article == null) return NotFound();


            ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryId", "Name");

            return View(Article);
        }

        // POST: Vehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Article  article)
        {
            if (id != article.ArticleId) return NotFound();


            try
            {
                _context.Update(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Puedes loguear el error si tienes logging
                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar el vehículo. Intente de nuevo.");
            }

            ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryId", "Name");
            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        private bool VehicleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }
    }
}
