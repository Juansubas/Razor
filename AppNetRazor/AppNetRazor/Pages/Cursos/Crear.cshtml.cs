using AppNetRazor.Datos;
using AppNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppNetRazor.Pages.Cursos
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public CrearModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Curso Curso { get; set; }

        [TempData]
        public string Mensaje { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Curso.FechaCreacion = DateTime.Now;

            _contexto.Add(Curso);

            await _contexto.SaveChangesAsync();
            Mensaje = "Curso Creado Correctamente";
            return RedirectToPage("Index");
        }
    }
}
