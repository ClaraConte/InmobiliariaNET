using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class Usuario
    {
        [Display(Name = "Código")]
        [Key]
        public int IdUsuario { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        public string UsuarioNombre { get; set; }

        [Display(Name = "Apellido")]
        [Required]
        public string UsuarioApellido { get; set; }

        [Display(Name = "DNI")]
        [Required]
        public string UsuarioDni { get; set; }

        [Display(Name = "Teléfono")]
        [Required]
        public string UsuarioTelefono { get; set; }

        [Display(Name = "Email")]
        [Required, EmailAddress]
        public string UsuarioEmail { get; set; }
        [Required, DataType(DataType.Password)]
        public string UsuarioClave { get; set; }
        [Required]
        public string UsuarioSalt { get; set; }
        [Required]

        [Display(Name = "Código")] public string UsuarioDomicilio { get; set; }
        [Required]
        public UsuarioTipo IdUsuarioTipo { get; set; }
    }
}
