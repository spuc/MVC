using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using claseMVCts.Recursos;


namespace claseMVCts.Models
{
    public class libro
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "* {0} Requerido")]
        [Required(ErrorMessageResourceName = "CampoRequerido",
            ErrorMessageResourceType = typeof(mensajes))]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "El {0} debe ser de al menos {2} caracteres.")]
        //[DataType(DataType.Password)]
        public string Titulo { get; set; }

        [Required]
        //[Compare("Titulo", ErrorMessage = "el  {0} debe ser igual al titulo")]
        public string Autor { get; set; }

        [Required]        
        public string Genero { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Publicación")]
        public DateTime Fecha { get; set; }

        [Required]
        //[RegularExpression(@"(^\d+$)|(^\.\d{1,4}$)|(^\d*\.\d{0,4}$)")]
        public decimal precio { get; set; }

        public string ruta { get; set; }

    }

    public class LibroDBContext : DbContext
    {
        public LibroDBContext()
            : base("LibroConnection")
        {
        }      

        public DbSet<libro> libros { get; set; }
    }



}

