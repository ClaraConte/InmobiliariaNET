using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class Inmueble
    {
        [Display(Name = "Código")]
        [Key]
        public int IdInmueble { get; set; }
        [Display(Name = "Dirección")]
        public String InmuebleDomicilio { get; set; }
        [Display(Name = "Latitud")]
        public Decimal InmuebleLatitud { get; set; }
        [Display(Name = "Longitud")]
        public Decimal InmuebleLongitud { get; set; }
        [Display(Name = "Precio")]
        public Decimal InmueblePrecio { get; set; }
        [Display(Name = "Ambientes")]
        public int InmuebleAmbientes { get; set; }
        [Display(Name = "Estado")]
        public byte InmuebleEstado { get; set; }
        public int IdInmuebleUso { get; set; }

        [Display(Name = "Uso")]
        [ForeignKey("IdInmuebleUso")]
        public InmuebleUso InmuebleUso { get; set; }

        public int IdInmuebleTipo { get; set; }

        [ForeignKey("IdInmuebleTipo")]
        [Display(Name = "Tipo")]
        public InmuebleTipo InmuebleTipo { get; set; }

        public int IdUsuario { get; set; }

        [Display(Name = "Propietario")]
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
    }
}
