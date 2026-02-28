using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using SystemVehiControl.ApplicationContext;

namespace SystemVehiControl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VehixControlContext _context;

        public HomeController(ILogger<HomeController> logger, VehixControlContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            var clientsCount = await _context.Clients.CountAsync();
            var usersCount = await _context.Users.CountAsync();
            var vehicles = await _context.Vehicles.CountAsync();
            var serviceCases = await _context.ServiceCases.CountAsync();

            ViewBag.ClientsCount = clientsCount;
            ViewBag.UsersCount = usersCount;
            ViewBag.Vehicles = vehicles;
            ViewBag.ServiceCases = serviceCases;

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
