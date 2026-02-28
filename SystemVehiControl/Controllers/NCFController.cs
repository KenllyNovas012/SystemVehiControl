using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SystemVehiControl.ApplicationContext;
using SystemVehiControl.Dto;
using SystemVehiControl.Models;

namespace SystemVehiControl.Controllers
{
    public class NCFController : Controller
    {
        private readonly VehixControlContext _context;
        public NCFController(VehixControlContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            return View(await _context.NCFs.ToListAsync());
        }
        //public async Task<IEnumerable<NCFDto>> Index()
        //{
        //    var ncf = await _context.NCFs.ToListAsync();

        //    var result = ncf.Select(n => new NCFDto
        //    {
        //        Id = n.Id,
        //        TipoNCF = n.NCFType,
        //        RangoInicio = n.StartRange,
        //        RangoFin = n.EndRange,
        //        SecuenciaActual = n.CurrentSequence,
        //        CodigoVerificacion = n.VerificationCode,
        //        Estado = n.Status,
        //        FechaCreacion = n.CreatedAt,
        //        FechaModificacion = n.UpdatedAt,
        //        // Calculamos la secuencia completa solo en el ViewModel
        //        SecuenciaCompleta = $"{n.NCFType}-{n.CurrentSequence.ToString().PadLeft(10, '0')}"
        //    }).ToList();

        //    return result;
        //}

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( NCFDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            NCF ncf = new NCF
            {
                NCFType = model.TipoNCF,
                StartRange = model.RangoInicio,
                EndRange = model.RangoFin,
                CurrentSequence = model.RangoInicio,
                VerificationCode = model.CodigoVerificacion,
                Status = model.Estado,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.NCFs.Add(ncf);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var Article = await _context.NCFs.FindAsync(id);
            if (Article == null) return NotFound();

            return View(Article);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NCFDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ncf = await _context.NCFs.FirstOrDefaultAsync(n => n.Id == id);

            if (ncf == null)
            {
                return NotFound();
            }

            ncf.NCFType = model.TipoNCF;
            ncf.StartRange = model.RangoInicio;
            ncf.EndRange = model.RangoFin;
            ncf.CurrentSequence = model.SecuenciaActual;
            ncf.VerificationCode = model.CodigoVerificacion;
            ncf.Status = model.Estado;
            ncf.UpdatedAt = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }
                

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var Brands = await _context.Brands.FindAsync(id);
            if (Brands == null)
            {
                return NotFound();
            }

            _context.Brands.Remove(Brands);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
