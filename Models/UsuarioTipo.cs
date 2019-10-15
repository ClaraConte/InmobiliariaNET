using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Inmobiliaria.Models
{
    public class UsuarioTipo
    {
        [Display(Name = "Código")]
        [Key]
        public int IdUsuarioTipo { get; set; }
        [Display(Name = "Rol")]
        [Required]
        public string UsuarioTipoRol { get; set; }
    }
}
