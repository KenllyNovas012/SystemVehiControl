using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using SystemVehiControl.ApplicationContext;
using SystemVehiControl.Models;

namespace SystemVehiControl.Controllers
{
    public class QuotationController : Controller
    {
        private readonly VehixControlContext _context;

        public QuotationController(VehixControlContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            var quotations = await _context.Quotations
                .Include(q => q.Person)
                .ToListAsync();

            TiposComprobante();

            return View(quotations);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var quotation = await _context.Quotations
                .Include(q => q.Details)
                .Include(q => q.Person)
                .FirstOrDefaultAsync(m => m.QuotationId == id);
            if (quotation == null) return NotFound();

            return View(quotation);
        }

        public IActionResult Create()
        {
            var model = new Quotation
            {
                DateTime = DateTime.Now,
                Details = new List<QuotationDetail>()
            };
            TiposComprobante();
            Clients();
            Articles();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Quotation quotation)
        {
            try
            {
                quotation.DateTime = DateTime.Now;
                quotation.Status = "Pendiente";
                quotation.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

                _context.Quotations.Add(quotation);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar la cotización. Intente de nuevo.");
            }

            Clients();
            Articles();
            TiposComprobante(quotation.ReceiptType);

            return RedirectToAction("Edit", new { id = quotation.QuotationId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var model = await _context.Quotations
                .Include(e => e.Details).Include(x => x.Person)
                .FirstOrDefaultAsync(e => e.QuotationId == id);

            if (model == null)
                return NotFound();

            TiposComprobante(model.ReceiptType);
            Clients(model.Person.PersonId);
            Articles();

            if (model.Details == null)
                model.Details = new List<QuotationDetail>();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Quotation quotation)
        {
            try
            {
                if (quotation.QuotationId == 0) return NotFound();

                quotation.Status = "Pendiente";
                quotation.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));      

                var QuotationDetails = await _context.QuotationDetails.Where(i => i.QuotationId == quotation.QuotationId).AsNoTracking().ToListAsync();
                var oldDetails = quotation.Details;

                ////Las filas que fueron eliminadas
                var DeleteRows = (from p in QuotationDetails
                                  where !(from b in oldDetails
                                          select b.QuotationId)
                                            .Contains(p.QuotationId)
                                  select p).Distinct().ToList();


                //Eliminamos las filas si existen
                if (DeleteRows.Count > 0)
                    _context.QuotationDetails.RemoveRange(DeleteRows);


                _context.Update(quotation);
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
            var quotation = await _context.Quotations.FindAsync(id);
            if (quotation == null)
            {
                return NotFound();
            }

            _context.Quotations.Remove(quotation);
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
