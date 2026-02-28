using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SystemVehiControl.ApplicationContext;
using SystemVehiControl.Dto;
using SystemVehiControl.Models;

namespace SystemVehiControl.Controllers
{
    public class UserController : Controller
    {
        private readonly VehixControlContext _context;
        private readonly IConfiguration _config;
        public UserController(VehixControlContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.Include(u => u.Role).ToListAsync();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = new SelectList(await _context.Roles.ToListAsync(), "RoleId", "Name");
            return View();
        }
        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CrearDto model)
        {
            if (!ModelState.IsValid)
            {
                // Si hay error en el modelo, devolver la vista con errores para que el usuario corrija
                return View(model);
            }

            var email = model.Email.ToLower();

            // Verificar si ya existe un usuario con ese email
            if (await _context.Users.AnyAsync(u => u.Email == email))
            {
                ModelState.AddModelError("email", "El email ya existe");
                return View(model);
            }

            // Crear el hash y salt de la contraseña
            CrearPasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User
            {
                RoleId = model.RoleId,
                Name = model.Name,
                DocumentType = model.DocumentType,
                DocumentNumber = model.DocumentNumber,
                Address = model.Address,
                Phone = model.Phone,
                Email = email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsActive = true
            };

            _context.Users.Add(user);

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirigir a la lista de usuarios
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al guardar el usuario.");
                return View(model);
            }
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            ViewBag.Roles = new SelectList(await _context.Roles.ToListAsync(), "RoleId", "Name", user.RoleId);

            // Crear un ViewModel para pasar a la vista, si usas uno
            var model = new CrearDto
            {
                UserId = user.UserId,
                RoleId = user.RoleId,
                Name = user.Name,
                DocumentType = user.DocumentType,
                DocumentNumber = user.DocumentNumber,
                Address = user.Address,
                Phone = user.Phone,
                Email = user.Email,
                // Password is normally not included during edit
            };

            return View(model);
        }

        public async Task<IActionResult> Perfil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            ViewBag.Roles = new SelectList(await _context.Roles.ToListAsync(), "RoleId", "Name", user.RoleId);

            // Crear un ViewModel para pasar a la vista, si usas uno
            var model = new CrearDto
            {
                UserId = user.UserId,
                RoleId = user.RoleId,
                Name = user.Name,
                DocumentType = user.DocumentType,
                DocumentNumber = user.DocumentNumber,
                Address = user.Address,
                Phone = user.Phone,
                Email = user.Email,
                // Password is normally not included during edit
            };

            return View(model);
        }



        // POST: Usuarios/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CrearDto model)
        {
            if (id != model.UserId)
            {
                return BadRequest();
            }

            
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Validar que el email no esté repetido en otro usuario
            var email = model.Email.ToLower();
            if (await _context.Users.AnyAsync(u => u.Email == email && u.UserId != id))
            {
                ModelState.AddModelError("email", "El email ya existe");
                return View(model);
            }

            // Actualizar campos
            user.RoleId = model.RoleId;
            user.Name = model.Name;
            user.DocumentType = model.DocumentType;
            user.DocumentNumber = model.DocumentNumber;
            user.Address = model.Address;
            user.Phone = model.Phone;
            user.Email = email;
            user.IsActive = model.IsActive;

            // Si deseas actualizar la contraseña solo si el usuario ingresa una nueva
            if (!string.IsNullOrEmpty(model.Password))
            {
                CrearPasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error al actualizar el usuario.");
                return View(model);
            }
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Usuarios = await _context.Users.FindAsync(id);
            if (Usuarios == null)
            {
                return NotFound();
            }

            _context.Users.Remove(Usuarios);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(Usuarios);
        }

      
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var email = model.email.ToLower();

            var usuario = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email && u.IsActive);

            if (usuario == null || !VerificarPasswordHash(model.password, usuario.PasswordHash, usuario.PasswordSalt))
            {
                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
                return View(model); // vuelve a mostrar el login con error
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.UserId.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Name, usuario.Name),
                new Claim(ClaimTypes.Role, usuario.Role.Name)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home"); // 👈 Redirige a la vista Index
        }
        private bool VerificarPasswordHash(string password, byte[] passwordHashAlmacenado, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passwordHashNuevo = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return new ReadOnlySpan<byte>(passwordHashAlmacenado).SequenceEqual(new ReadOnlySpan<byte>(passwordHashNuevo));
            }
        }

        private string GenerarToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              _config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds,
              claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var Users = await _context.Users.FindAsync(id);
            if (Users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(Users);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            // Cierra sesión
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirige a la página de inicio o login
            return RedirectToAction("Index", "Home");
        }
    }
}
