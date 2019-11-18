using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inmobiliaria.Models
{
    public class InmuebleUso
    {
        [Display(Name = "Código")]
        [Key]
        public int IdInmuebleUso { get; set; }
        public String InmuebleUsoNombre { get; set; }
    }
}
