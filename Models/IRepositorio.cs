using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public interface IRepositorioUsuario<T>
    { 
        int Add(T p);
        int Delete(T p);
        int Update(T p);
        List<T> GetAll();
        T GetAllById(int id);
    }
}
