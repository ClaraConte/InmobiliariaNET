using System.Collections.Generic;

namespace Inmobiliaria.Models
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        Usuario GetByEmail(string email);
        IList<Usuario> GetByType(int idUsuarioTipo);
        IList<Usuario> GetByCriterio(BusquedaView busqueda);
    }
}
