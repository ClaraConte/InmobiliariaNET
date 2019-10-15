using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class BusquedaView
    {
        public int Tipo { get; set; }

        [StringLength(10)]
        [RegularExpression(@"[A-Za-z]*", ErrorMessage = "Caracteres incorrectos")]
        public string Criterio { get; set; }
        public String Campo { get; set; }
    }
}
