using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inmobiliaria.Models
{
    public class InmuebleTipo
    {
        [Display(Name = "Código")]
        [Key]
        public int IdInmuebleTipo { get; set; }
        public String InmuebleTipoNombre { get; set; }

    }
}
