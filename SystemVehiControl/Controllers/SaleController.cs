using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using SystemVehiControl.ApplicationContext;
using SystemVehiControl.Models;

namespace SystemVehiControl.Controllers
{
    public class SaleController : Controller
    {
        private readonly VehixControlContext _context;

        public SaleController(VehixControlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            var sales = await _context.Sales
                .Include(s => s.Person)
                .ToListAsync();

            TiposComprobante(); 

            return View(sales);
        }
        public IActionResult Print(int id)
        {
            var sale = _context.Sales
                .Include(s => s.Person)
                .Include(s => s.User)
                .Include(s => s.Details)
                    .ThenInclude(d => d.Article)
                .FirstOrDefault(s => s.SaleId == id);

            if (sale == null)
                return NotFound();

            return View(sale);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var sale = await _context.Sales
                .Include(s => s.Details)
                .Include(s => s.Person)
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (sale == null) return NotFound();

            return View(sale);
        }

        public IActionResult Create()
        {
            var model = new Sale
            {
                DateTime = DateTime.Now,
                Details = new List<SaleDetail>()
            };
            TiposComprobante();
            Clients();
            Articles();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sale sale)
        {
            try
            {
                sale.DateTime = DateTime.Now;
                sale.Status = "Facturada";
                sale.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

                _context.Sales.Add(sale);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar la venta. Intente de nuevo.");
            }

            Clients();
            Articles();
            TiposComprobante(sale.ReceiptType);

            return RedirectToAction("Edit", new { id = sale.SaleId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var model = await _context.Sales
                .Include(e => e.Details).Include(x => x.Person)
                .FirstOrDefaultAsync(e => e.SaleId == id);

            if (model == null)
                return NotFound();

            TiposComprobante(model.ReceiptType);
            Clients(model.Person.PersonId);
            Articles();

            if (model.Details == null)
                model.Details = new List<SaleDetail>();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Sale sale)
        {
            try
            {
                if (sale.SaleId == 0) return NotFound();

                sale.Status = "Facturada";
                sale.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));      

                var SaleDetails = await _context.SaleDetails.Where(i => i.SaleId == sale.SaleId).AsNoTracking().ToListAsync();
                var oldDetails = sale.Details;

                ////Las filas que fueron eliminadas
                var DeleteRows = (from p in SaleDetails
                                  where !(from b in oldDetails
                                          select b.SaleId)
                                            .Contains(p.SaleId)
                                  select p).Distinct().ToList();

                //Eliminamos las filas si existen
                if (DeleteRows.Count > 0)
                    _context.SaleDetails.RemoveRange(DeleteRows);

                _context.Update(sale);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar la venta. Intente de nuevo.");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public dynamic TiposComprobante(string selected = null) => ViewBag.ReceiptTypes = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "000", Text = "Factura de Consumo" },
                new SelectListItem { Value = "B01", Text = "Factura de Consumo (B01)" },
                new SelectListItem { Value = "B02", Text = "Crédito Fiscal (B02)" },
                new SelectListItem { Value = "B03", Text = "Regímenes Especiales (B03)" }
            }, "Value", "Text", selected);
        public dynamic Clients(int? selected = null) => ViewBag.Clients = new SelectList(_context.People.Where(x => x.PersonType == "Cliente"), "PersonId", "Name", selected);
        public dynamic Articles() => ViewBag.Articles = new SelectList(_context.Articles, "ArticleId", "Name");
    }
}
