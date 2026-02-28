using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using SystemVehiControl.ApplicationContext;
using SystemVehiControl.Dto;
using SystemVehiControl.Helper;
using SystemVehiControl.Models;

namespace SystemVehiControl.Controllers
{
    public class ServiceCaseController : Controller
    {
        private readonly VehixControlContext _context;
        private readonly IEmailService _emailService;
        public ServiceCaseController(VehixControlContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                comment.UserId = userId;
            }
            else
            {
                // Si no hay usuario, opcional: asignar un valor por defecto o devolver error
                comment.UserId = 0; // o -1 para "Sistema"
            }


            if (!string.IsNullOrWhiteSpace(comment.Text))
            {
                comment.CreatedAt = DateTime.Now;

                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Edit", new { id = comment.ServiceCaseId });
        }

        // GET: ServiceCase
        public async Task<IActionResult> Index()
        {
            var serviceCases = await _context.ServiceCases
                .Include(sc => sc.VehicleReception)
                .Include(sc => sc.GetUser)
                .Include(sc => sc.ServiceType) // Incluir el tipo de servicio
                .Include(sc => sc.Priority)    // Incluir la prioridad
                .ToListAsync();

            return View(serviceCases);
        }
        public IActionResult Print(int id)
        {
            //var serviceCase = _context.ServiceCases
            //    .Include(s => s.VehicleReception)
            //    .Include(s => s.ServiceType)
            //    .Include(s => s.Priority)
            //    .Include(s => s.GetUser)
            //    .FirstOrDefault(s => s.Id == id);
            var serviceCase = _context.ServiceCases
            .Include(s => s.VehicleReception)
                .ThenInclude(vr => vr.Vehicle)
                    .ThenInclude(v => v.Brand)
            .Include(s => s.VehicleReception)
                .ThenInclude(vr => vr.Client)
            .Include(s => s.ServiceType)
            .Include(s => s.Priority)
            .Include(s => s.GetUser)
            .FirstOrDefault(s => s.Id == id);

            if (serviceCase == null)
                return NotFound();

            return View(serviceCase);
        }
        public async Task<IActionResult> IndexList()
        {
            var serviceCases = await _context.ServiceCases
                .Include(sc => sc.VehicleReception)
                .Include(sc => sc.GetUser)
                .Include(sc => sc.ServiceType)
                .Include(sc => sc.Priority)
                .Select(sc => new ServiceCaseViewModel
                {
                    ServiceCase = sc,
                    LastComment = sc.Comments
                        .OrderByDescending(c => c.CreatedAt)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return View(serviceCases);
        }
        // GET: ServiceCase/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var serviceCase = await _context.ServiceCases
                .Include(sc => sc.VehicleReception)
                .Include(sc => sc.GetUser)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (serviceCase == null)
                return NotFound();

            return View(serviceCase);
        }

        public IActionResult Create()
        {
            ViewData["VehicleReceptions"] = new SelectList(_context.VehicleReceptions.ToList(), "VehicleReceptionId", "OrderNumber");
            ViewData["ServiceTypes"] = new SelectList(_context.ServiceTypes.ToList(), "ServiceTypeId", "Name");
            ViewData["Priorities"] = new SelectList(_context.Priorities.ToList(), "PriorityId", "Level");
            ViewData["Users"] = new SelectList(_context.Users.Include(u => u.Role).Where(u => u.Role.Name == "Mecánico").ToList(), "UserId", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceCase serviceCase)
        {
            try
            {
                _context.Add(serviceCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Puedes loguear el error si tienes logging
                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar el vehículo. Intente de nuevo.");
            }
            // Si falla validación, recargar listas para la vista
            ViewData["VehicleReceptions"] = new SelectList(_context.VehicleReceptions.ToList(), "VehicleReceptionId", "OrderNumber");
            ViewData["ServiceTypes"] = new SelectList(_context.ServiceTypes.ToList(), "ServiceTypeId", "Name");
            ViewData["Priorities"] = new SelectList(_context.Priorities.ToList(), "PriorityId", "Level");
            ViewData["Users"] = new SelectList(_context.Users.Include(u => u.Role).Where(u => u.Role.Name == "Mecánico").ToList(), "UserId", "Name");

            return View(serviceCase);
        }

        // GET: ServiceCase/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.EsAdmin = User.IsInRole("Administrador");
            var serviceCase = await _context.ServiceCases.FindAsync(id.Value);
            if (serviceCase == null)
            {
                return NotFound();
            }
            var comments = await _context.Comments.Where(c => c.ServiceCaseId == serviceCase.Id).ToListAsync();

            ViewData["Comments"] = comments;
            ViewData["VehicleReceptions"] = new SelectList(_context.VehicleReceptions.ToList(), "VehicleReceptionId", "OrderNumber");
            ViewData["ServiceTypes"] = new SelectList(_context.ServiceTypes.ToList(), "ServiceTypeId", "Name");
            ViewData["Priorities"] = new SelectList(_context.Priorities.ToList(), "PriorityId", "Level");
            ViewData["Users"] = new SelectList(_context.Users.Include(u => u.Role).Where(u => u.Role.Name == "Mecánico").ToList(), "UserId", "Name");

            return View(serviceCase);
        }

        // POST: ServiceCase/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceCase serviceCase)
        {
            if (id != serviceCase.Id)
                return NotFound();

            try
            {
                _context.Update(serviceCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Puedes loguear el error si tienes logging
                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar el vehículo. Intente de nuevo.");
            }

            return View(serviceCase);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var ServiceCases = await _context.ServiceCases.FindAsync(id);
            if (ServiceCases == null)
            {
                return NotFound();
            }

            _context.ServiceCases.Remove(ServiceCases);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]

        public async Task<IActionResult> UpdateStatus([FromBody] ServiceCase model)
        {
            var serviceCase = await _context.ServiceCases.FindAsync(model.Id);
            if (serviceCase == null)
            {
                return NotFound();
            }

            serviceCase.Status = model.Status;
            await _context.SaveChangesAsync();


            return Ok(new { message = "Estado actualizado correctamente" });
        }
        private bool ServiceCaseExists(int id)
        {
            return _context.ServiceCases.Any(e => e.Id == id);
        }
    }
}
