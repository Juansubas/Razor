using AppNetRazor.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AppNetRazor.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //Aqui van los modelos
        public DbSet<Curso> Curso { get; set; }
    }
}