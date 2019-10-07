using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class UsuarioTipo
    {
        [Key]
        public int IdUsuarioTipo { get; set; }
        [Required]
        public string UsuarioTipoRol { get; set; }
    }
}
