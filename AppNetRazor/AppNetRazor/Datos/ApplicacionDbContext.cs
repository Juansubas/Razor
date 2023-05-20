using AppNetRazor.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AppNetRazor.Datos
{
    public class ApplicacionDbContext : DbContext
    {
        public ApplicacionDbContext(DbContextOptions<ApplicacionDbContext> options) : base(options)
        {
            
        }

        //Aqui van los modelos
        public DbSet<Curso> Curso { get; set; }
    }
}