using AppNetRazor.Datos;
using AppNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppNetRazor.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicacionDbContext _contexto;
        public IEnumerable<Curso> Cursos { get; set; }

        public IndexModel(ApplicacionDbContext contexto)
        {
            _contexto = contexto;
        }
        public async Task OnGet()
        {
            Cursos = await _contexto.Curso.ToListAsync();
        }
    }
}
