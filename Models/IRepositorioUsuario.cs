using System.Collections.Generic;

namespace Inmobiliaria.Models
{
    public interface IRepositorioUsuario : IRepositorioUsuario<Usuario>
    {
        Usuario GetByEmail(string email);
        IList<Usuario> GetByType(int idUsuarioTipo);
    }
}
