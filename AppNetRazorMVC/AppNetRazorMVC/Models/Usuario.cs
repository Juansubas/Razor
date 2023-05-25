using System.ComponentModel.DataAnnotations;

namespace AppNetRazorMVC.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El telefono es obligatorio")]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El celular es obligatorio")]
        public string Celular { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; } = string.Empty;


    }
}
