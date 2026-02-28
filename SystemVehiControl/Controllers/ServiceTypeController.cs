using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemVehiControl.ApplicationContext;
using SystemVehiControl.Models;

namespace SystemVehiControl.Controllers
{
    public class ServiceTypeController : Controller
    {
        private readonly VehixControlContext _context;

        public ServiceTypeController(VehixControlContext context)
        {
            _context = context;
        }

        // GET: ServiceType
        public async Task<IActionResult> Index()
        {
            var serviceTypes = await _context.ServiceTypes.ToListAsync();
            return View(serviceTypes);
        }

        // GET: ServiceType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var serviceType = await _context.ServiceTypes.FirstOrDefaultAsync(m => m.ServiceTypeId == id);

            if (serviceType == null)
                return NotFound();

            return View(serviceType);
        }

        // GET: ServiceType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ServiceType serviceType)
        {
            try
            {
                _context.Add(serviceType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Puedes loguear el error si tienes logging
                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar el vehículo. Intente de nuevo.");
            }
            return View(serviceType);
        }

        // GET: ServiceType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var serviceType = await _context.ServiceTypes.FindAsync(id);

            if (serviceType == null)
                return NotFound();

            return View(serviceType);
        }

        // POST: ServiceType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  ServiceType serviceType)
        {
            if (id != serviceType.ServiceTypeId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceType);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    // Puedes loguear el error si tienes logging
                    ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar el vehículo. Intente de nuevo.");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(serviceType);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var ServiceTypes = await _context.ServiceTypes.FindAsync(id);
            if (ServiceTypes == null)
            {
                return NotFound();
            }

            _context.ServiceTypes.Remove(ServiceTypes);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ServiceTypeExists(int id)
        {
            return _context.ServiceTypes.Any(e => e.ServiceTypeId == id);
        }
    }
}
