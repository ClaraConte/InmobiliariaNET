using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class RepositorioPropietario: RepositorioUsuario
    {
        public RepositorioPropietario(IConfiguration configuration) : base(configuration)
        {
            
        }
    }
}
