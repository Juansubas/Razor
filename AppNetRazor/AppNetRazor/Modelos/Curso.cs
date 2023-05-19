﻿using System.ComponentModel.DataAnnotations;

namespace AppNetRazor.Modelos
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre de Curso")]
        public string NombreCurso { get; set; }
        [Display(Name = "Cantidad de Clases")]
        public int CantidadClase { get; set; }
        public int Precio { get; set; }
        [Display(Name = "Fecha de Creacion")]
        public DateTime FechaCreacion { get; set; }

    }
}
