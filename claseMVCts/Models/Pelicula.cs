using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace claseMVCts.Models
{
    public partial class Pelicula
    {
        public int id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string ActorPrincipal { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", 
            ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Estreno { get; set; }
        
        public Nullable<decimal> Precio { get; set; }
        public string otro { get; set; }
    }
}
