using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class ContratoGarantia
    {
        [Display(Name = "Código")]
        [Key]
        public int IdContratoGarantia { get; set; }

        public int IdUsuario { get; set; }

        [Display(Name = "Usuario")]
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public int IdContrato { get; set; }

        [Display(Name = "Contrato")]
        [ForeignKey("IdContrato")]
        public Contrato Contrato { get; set; }
    }
}
