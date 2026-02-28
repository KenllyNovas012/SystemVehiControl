using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using SystemVehiControl.ApplicationContext;
using SystemVehiControl.Models;

namespace SystemVehiControl.Controllers
{
    public class StockEntryController : Controller
    {
        private readonly VehixControlContext _context;

        public StockEntryController(VehixControlContext context)
        {
            _context = context;
        }
        // GET: Brands
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            var receptions = await _context.StockEntries
               .Include(v => v.Supplier)
               .ToListAsync();

            TiposComprobante();

            return View(receptions);
        }

        // GET: Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var brand = await _context.StockEntries
                .FirstOrDefaultAsync(m => m.StockEntryId == id);
            if (brand == null) return NotFound();

            return View(brand);
        }

        // GET: Brands/Create
        public IActionResult Create()
        {
            var model = new StockEntry
            {
                DateTime = DateTime.Now,
                Details = new List<StockEntryDetail>() // 🔥 esto evita que sea null en la vista
            };

            TiposComprobante();
            Suppliers();
            Articles();

            return View(model); // 👈 importante
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockEntry stockEntry)
        {
            try
            {
                var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
                stockEntry.DateTime = DateTime.Now;
                stockEntry.Status = "Pendiente";
                stockEntry.UserId = (int)Convert.ToInt64(user);

                _context.StockEntries.Add(stockEntry);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Puedes loguear el error si tienes logging
                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar el vehículo. Intente de nuevo.");
            }

            Articles();
            Suppliers(stockEntry.SupplierId);
            TiposComprobante(stockEntry.ReceiptType);

            return RedirectToAction("Edit", new { id = stockEntry.StockEntryId });
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var model = await _context.StockEntries
                .Include(e => e.Details)
                .FirstOrDefaultAsync(e => e.StockEntryId == id);

            if (model == null)
                return NotFound();


            TiposComprobante(model.ReceiptType);
            Suppliers(model.SupplierId);
            Articles();

            // 🔥 Asegura que haya al menos una lista inicializada
            if (model.Details == null)
                model.Details = new List<StockEntryDetail>();

            return View("Edit", model);
        }

        // POST: Brands/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(StockEntry stockEntry)
        {
            try
            {
                if (stockEntry.StockEntryId == 0) return NotFound();

                stockEntry.Status = "Pendiente";
                stockEntry.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

                var StockEntryDetails = await _context.StockEntryDetails.Where(i => i.StockEntryId == stockEntry.StockEntryId).AsNoTracking().ToListAsync();
                var oldDetails = stockEntry.Details;

                ////Las filas que fueron eliminadas
                var DeleteRows = (from p in StockEntryDetails
                                  where !(from b in oldDetails
                                          select b.StockEntryDetailId)
                                            .Contains(p.StockEntryDetailId)
                                  select p).Distinct().ToList();


                //Eliminamos las filas si existen
                if (DeleteRows.Count > 0)
                    _context.StockEntryDetails.RemoveRange(DeleteRows);


                _context.Update(stockEntry);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Puedes loguear el error si tienes logging
                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar el vehículo. Intente de nuevo.");

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var Brands = await _context.StockEntries.FindAsync(id);
            if (Brands == null)
            {
                return NotFound();
            }

            _context.StockEntries.Remove(Brands);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public dynamic TiposComprobante(object? ReceiptType = null) => ViewBag.TiposComprobante = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "000", Text = "Factura de Consumo" },
                new SelectListItem { Value = "B01", Text = "Factura de Consumo (B01)" },
                new SelectListItem { Value = "B02", Text = "Crédito Fiscal (B02)" },
                new SelectListItem { Value = "B03", Text = "Regímenes Especiales (B03)" }
            }, "Value", "Text", ReceiptType);

        private bool BrandExists(int id) => _context.Brands.Any(e => e.BrandId == id);

        public dynamic Suppliers(object? person = null) => ViewBag.Suppliers = new SelectList(_context.People.Where(p => p.PersonType == "Supplier"), "PersonId", "Name", person);
        public dynamic Articles() => ViewBag.Articles = new SelectList(_context.Articles, "ArticleId", "Name");
    }
}
