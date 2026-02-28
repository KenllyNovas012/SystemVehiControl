using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SystemVehiControl.ApplicationContext;
using SystemVehiControl.Dto;
using SystemVehiControl.Models;

namespace SystemVehiControl.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly VehixControlContext _context;

        public SuppliersController(VehixControlContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            var suppliers = await _context.People
                .Where(p => p.PersonType == "Supplier") // o "Suppliers", según cómo lo tengas guardado
                .OrderByDescending(p => p.Name)
                .ToListAsync();

            return View(suppliers);
        }

        public IActionResult Create()
        {
            return View(); // Muestra el formulario vacío
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Muestra el formulario con los errores
            }

            var email = model.Email.ToLower();

            if (await _context.People.AnyAsync(p => p.Email == email))
            {
                ModelState.AddModelError("Email", "El correo ya está registrado");
                return View(model);
            }

            Person client = new Person
            {
                Name = model.Name,                 // asumiendo que 'Name' es el nombre completo
                DocumentType = model.DocumentType,
                DocumentNumber = model.DocumentNumber,  // aquí usas DocumentNumber para IdentificationNumber
                Address = model.Address,
                Phone = model.Phone,            // Phone en el DTO va a MobileNumber
                Email = email,    
                PersonType= "Supplier"// email en minúscula que ya definiste
            };

            try
            {
                _context.People.Add(client);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar los datos.");
                return View(model);
            }

            return RedirectToAction("Index"); // Redirige a la lista de personas
        }

        public async Task<IActionResult> Edit(int id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }
            ViewBag.DocumentTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Cédula", Value = "Cédula" },
                new SelectListItem { Text = "Pasaporte", Value = "Pasaporte" },
                new SelectListItem { Text = "Licencia", Value = "Licencia" }
            };

            return View(person); // Devuelve la vista Edit con el modelo
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Person model)
        {
            if (id != model.PersonId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model); // Retorna la vista con errores de validación
            }

            var email = model.Email.ToLower();

            // Verifica que no haya otra persona con el mismo email
            if (await _context.Clients.AnyAsync(p => p.Email == email && p.Id != id))
            {
                ModelState.AddModelError("Email", "El correo ya está registrado");
                return View(model);
            }

            try
            {
                var client = await _context.People.FindAsync(id);
                if (client == null)
                {
                    return NotFound();
                }

                // Actualiza los campos
                client.Name = model.Name;
                client.DocumentType = model.DocumentType;
                client.DocumentNumber = model.DocumentNumber;
                client.Address = model.Address;
                client.Phone = model.Phone;
                client.Email = model.Email.ToLower();

                _context.Update(client);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar los cambios.");
                return View(model);
            }

            return RedirectToAction("Index"); // Redirige a la lista
        }

        // PUT: api/People/Update
        [Authorize(Roles = "WarehouseStaff,Administrator,Seller")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] PersonDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.PersonId <= 0)
            {
                return BadRequest();
            }

            var person = await _context.People.FirstOrDefaultAsync(p => p.PersonId == model.PersonId);

            if (person == null)
            {
                return NotFound();
            }

            person.PersonType = model.PersonType;
            person.Name = model.Name;
            person.DocumentType = model.DocumentType;
            person.DocumentNumber = model.DocumentNumber;
            person.Address = model.Address;
            person.Phone = model.Phone;
            person.Email = model.Email.ToLower();

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
            var client = await _context.People.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.People.Remove(client);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Helper method to check existence
        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.PersonId == id);
        }
    }
}
