using AppNetRazor.Datos;
using AppNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppNetRazor.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public IEnumerable<Curso> Cursos { get; set; }

        public IndexModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public async Task OnGet()
        {
            Cursos = await _contexto.Curso.ToListAsync();
        }

        public async Task<IActionResult> OnPostBorrarAsync(int id)
        {
            var curso = await _contexto.Curso.FindAsync(id);

            if (curso is null) return NotFound();

            _contexto.Curso.Remove(curso);

            await _contexto.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
