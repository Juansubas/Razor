using AppNetRazorMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AppNetRazorMVC.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        //Usar los modelos

        public DbSet<Usuario> Usuario { get; set; }
    }
}
