using AppNetRazorMVC.Datos;
using AppNetRazorMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AppNetRazorMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Usuario usuario) 
        { 
            if(ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id is null) return NotFound();

            var usuario =  _context.Usuario.Find(id);

            if (usuario is null) return NotFound();

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            if (id is null) return NotFound();

            var usuario = _context.Usuario.Find(id);

            if (usuario is null) return NotFound();

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Usuario usuario)
        {
            if (usuario is null) return NotFound();

            _context.Usuario.Remove(usuario);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}