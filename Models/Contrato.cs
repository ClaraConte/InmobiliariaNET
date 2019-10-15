using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class Contrato
    {
        [Display(Name = "Código")]
        [Key]
        public int IdContrato { get; set; }
        [Display(Name = "Detalle del contrato")]
        public String ContratoDetalle { get; set; }

        [Required]
        [Display(Name = "Inicio")]
        [DataType(DataType.Date)]
        public DateTime ContratoFechaInicio { get; set; }

        [Required]
        [Display(Name = "Fin")]
        [DataType(DataType.Date)]
        public DateTime ContratoFechaFin { get; set; }

        [Required]
        [Display(Name = "Precio")]
        [Column(TypeName = "decimal(18,0)")]
        public Decimal ContratoPrecio { get; set; }

        [Display(Name = "Estado")]
        public Byte ContratoEstado { get; set; }

        [Required]
        public int IdInmueble { get; set; }

        [Display(Name = "Inmueble")]
        [ForeignKey("IdInmueble")]
        public Inmueble Inmueble { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Display(Name = "Inquilino")]
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

    }
}
