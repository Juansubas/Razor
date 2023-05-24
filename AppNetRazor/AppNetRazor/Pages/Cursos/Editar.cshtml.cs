using AppNetRazor.Datos;
using AppNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppNetRazor.Pages.Cursos
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public EditarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Curso Curso { get; set; }
        [TempData]
        public string Mensaje { get; set; }
        public async void OnGet(int id)
        {
            Curso = await _contexto.Curso.FindAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var CursoDesdeDb = await _contexto.Curso.FindAsync(Curso.Id);

                CursoDesdeDb.NombreCurso = Curso.NombreCurso;
                CursoDesdeDb.CantidadClase = Curso.CantidadClase;
                CursoDesdeDb.Precio = Curso.Precio;


                await _contexto.SaveChangesAsync();
                Mensaje = "Curso Editado Correctamente";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
