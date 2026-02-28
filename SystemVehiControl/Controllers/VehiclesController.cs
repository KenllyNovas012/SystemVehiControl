using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SystemVehiControl.ApplicationContext;
using SystemVehiControl.Models;

namespace SystemVehiControl.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly VehixControlContext _context;

        public VehiclesController(VehixControlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var vehicles = _context.Vehicles.Include(v => v.Brand);

            return View(await vehicles.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var vehicle = await _context.Vehicles
                .Include(v => v.Brand)
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicle == null) return NotFound();

            return View(vehicle);
        }

        // GET: Vehicles/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["EngineId"] = new SelectList(await _context.Engines.ToListAsync(), "Id", "Name");
            ViewData["BrandId"] = new SelectList(await _context.Brands.ToListAsync(), "BrandId", "Name");

            ViewBag.FuelTypeList = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Seleccione un combustible", Selected = true },
                new SelectListItem { Value = "Gasolina", Text = "Gasolina" },
                new SelectListItem { Value = "Diesel", Text = "Diesel" },
                new SelectListItem { Value = "Eléctrico", Text = "Eléctrico" },
                new SelectListItem { Value = "Gas", Text = "Gas" },
            };
            return View();
        }

        // POST: Vehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            try
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Puedes loguear el error si tienes logging
                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar el vehículo. Intente de nuevo.");
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "Name", vehicle.BrandId);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null) return NotFound();

            ViewBag.FuelTypeList = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "Seleccione un combustible", Selected = true },
                new SelectListItem { Value = "Gasolina", Text = "Gasolina" },
                new SelectListItem { Value = "Diesel", Text = "Diesel" },
                new SelectListItem { Value = "Eléctrico", Text = "Eléctrico" },
                new SelectListItem { Value = "Gas", Text = "Gas" },
            };

            ViewData["BrandId"] = new SelectList(await _context.Brands.ToListAsync(), "BrandId", "Name", vehicle.BrandId);
            ViewData["EngineId"] = new SelectList(await _context.Engines.ToListAsync(), "Id", "Name", vehicle.EngineId);

            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vehicle vehicle)
        {
            if (id != vehicle.VehicleId) return NotFound();


            try
            {
                _context.Update(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Puedes loguear el error si tienes logging
                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar el vehículo. Intente de nuevo.");
            }

            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "Name", vehicle.BrandId);
            return View(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var Vehicles = await _context.Vehicles.FindAsync(id);
            if (Vehicles == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(Vehicles);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.VehicleId == id);
        }
    }
}
